#include <WiFi.h>
#include <Wire.h>
#include <NetworkClient.h>
#include <WebServer.h>
#include <ESPmDNS.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>
#include <Adafruit_INA3221.h>
#include <ArduinoJson.h>
#include <NTPClient.h>
#include <WiFiUdp.h>

WiFiUDP ntpUDP;
NTPClient timeClient(ntpUDP);

String formattedDate;
String dayStamp;
String timeStamp;

Adafruit_BME280 bme;
Adafruit_INA3221 ina3221;
String JSON;
const char *ssid = "RT-GPON-3C30";
const char *password = "1q2w3e4r5t";
float temperature;
float humidity;
float pressure;
double s3221c40b1v;
double s3221c40b2v;
double s3221c40b3v;
double s3221c40b1a;
double s3221c40b2a;
double s3221c40b3a;

StaticJsonDocument<1000> jsonDocument;
char buffer[1000];

WebServer server(80);
void add_json_object(int Sensor, float value) {
  JsonObject obj = jsonDocument.createNestedObject();
  obj["Sensor_id"] = Sensor;
  obj["Station_id"] = 7;
  obj["Date_of_m"] = dayStamp; 
  obj["Time_of_m"] = timeStamp; 
  obj["Value_of_m"] = value; 
  obj["Unit_of_m"] = "1"; 
}
void read_sensor_data() {
     temperature = bme.readTemperature();
     humidity = bme.readHumidity();
     pressure = bme.readPressure() / 100 * 0.7500615;
     s3221c40b1v = ina3221.getBusVoltage(0);
     s3221c40b2v = ina3221.getBusVoltage(1);
     s3221c40b3a = ina3221.getCurrentAmps(2);

    for (uint8_t i = 0; i < 3; i++) {
    float voltage = ina3221.getBusVoltage(i);
    float current = ina3221.getCurrentAmps(i) * 1000; // Convert to mA
    float current2 = ina3221.getCurrentAmps(i);

    Serial.print("Channel ");
    Serial.print(i);
    Serial.print(": Voltage = ");
    Serial.print(voltage, 2);
    Serial.print(" V, Current = ");
    Serial.print(current, 2);
    Serial.println(" mA");
    Serial.print(current2, 2);
    Serial.println(" A");
  }
}
void getData() {
  Serial.println("Получен запрос");
  getDataTime();
  read_sensor_data();
  jsonDocument.clear();
  add_json_object(103, temperature);
  add_json_object(104, humidity);
  add_json_object(105, pressure);
  add_json_object(106, s3221c40b1v);
  add_json_object(107, s3221c40b2v);
  add_json_object(108, s3221c40b3a);
  serializeJson(jsonDocument, buffer);
  Serial.println((String) "Отправлено: 103:"+temperature+" 104:"+humidity+" 105:"+pressure+" 106:"+s3221c40b1v+" 107:"+s3221c40b2v+" 108:"+s3221c40b3v);
  server.send(200, "application/json", buffer);
}
void handleNotFound() {
  String message = "File Not Found\n\n";
  message += "URI: ";
  message += server.uri();
  message += "\nMethod: ";
  message += (server.method() == HTTP_GET) ? "GET" : "POST";
  message += "\nArguments: ";
  message += server.args();
  message += "\n";
  for (uint8_t i = 0; i < server.args(); i++) {
    message += " " + server.argName(i) + ": " + server.arg(i) + "\n";
  }
  server.send(404, "text/plain", message);
}
void getDataTime() {
  while(!timeClient.update()) {
    timeClient.forceUpdate();
  }
  formattedDate = timeClient.getFormattedDate();
  int splitT = formattedDate.indexOf("T");
  dayStamp = formattedDate.substring(0, splitT);
  timeStamp = formattedDate.substring(splitT+1, formattedDate.length()-1);
}
void setup(void) {
  Serial.begin(115200);
  delay(1000);

  // Initialize the BME280
  Serial.println("Инициализация BME280");
  if (!bme.begin(0x76)) {
    Serial.println("Датчик BME280 не обнаружен!");
  }

  // Initialize the INA3221
    Serial.println("Инициализация INA3221");
  if (!ina3221.begin(0x40, &Wire)) { // can use other I2C addresses or buses
    Serial.println("Датчик INA3221 не обнаружен");
  }

  ina3221.setAveragingMode(INA3221_AVG_16_SAMPLES);
    // Set shunt resistances for all channels to 0.05 ohms
  for (uint8_t i = 0; i < 3; i++) {
    ina3221.setShuntResistance(i, 0.05);
  }
  // Set a power valid alert to tell us if ALL channels are between the two
  // limits:
  ina3221.setPowerValidLimits(3.0 /* lower limit */, 15.0 /* upper limit */);

  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);
  Serial.println("Подключение к WIFI");

  // Wait for connection
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Подключен к ");
  Serial.println(ssid);
  Serial.print("IP адресс: ");
  Serial.println(WiFi.localIP());

  if (MDNS.begin("esp32")) {
    Serial.println("MDNS Запущен");
  }

  server.on("/", getData);
  server.onNotFound(handleNotFound);

  server.begin();
  Serial.println("HTTP Сервер запущен");

  timeClient.begin();
  timeClient.setTimeOffset(18000);
}

void loop(void) {
  server.handleClient();
  delay(2);  //allow the cpu to switch to other tasks
}
