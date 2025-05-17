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

//settings
const char *ssid = "RT-GPON-3C30";
const char *password = "1q2w3e4r5t";

const int s3221c40b1name = 1;
const int s3221c40b2name = 2;
const int s3221c40b3name = 3;
const int s3221c41b1name = 4;
const int s3221c41b2name = 5;
const int s3221c41b3name = 6;
const int s3221c42b1name = 7;
const int s3221c42b2name = 8;
const int s3221c42b3name = 9;
const int s3221c43b1name = 10;
const int s3221c43b2name = 11;
const int s3221c43b3name = 12;
//settings

WiFiUDP ntpUDP;
NTPClient timeClient(ntpUDP);

String formattedDate;
String dayStamp;
String timeStamp;

Adafruit_BME280 bme;
Adafruit_INA3221 ina3221с40;
Adafruit_INA3221 ina3221с41;
Adafruit_INA3221 ina3221с42;
Adafruit_INA3221 ina3221с43;
String JSON;

float temperature;
float humidity;
float pressure;
double s3221c40b1v;
double s3221c40b2v;
double s3221c40b3v;
double s3221c40b1a;
double s3221c40b2a;
double s3221c40b3a;

double s3221c41b1v;
double s3221c41b2v;
double s3221c41b3v;
double s3221c41b1a;
double s3221c41b2a;
double s3221c41b3a;

double s3221c42b1v;
double s3221c42b2v;
double s3221c42b3v;
double s3221c42b1a;
double s3221c42b2a;
double s3221c42b3a;

double s3221c43b1v;
double s3221c43b2v;
double s3221c43b3v;
double s3221c43b1a;
double s3221c43b2a;
double s3221c43b3a;

StaticJsonDocument<10000> jsonDocument;
char buffer[10000];

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

     s3221c40b1v = ina3221с40.getBusVoltage(0);
     s3221c40b1a = ina3221с40.getCurrentAmps(0);
     s3221c40b2v = ina3221с40.getBusVoltage(1);
     s3221c40b2a = ina3221с40.getCurrentAmps(1);
     s3221c40b3v = ina3221с40.getBusVoltage(2);
     s3221c40b3a = ina3221с40.getCurrentAmps(2);

     s3221c41b1v = ina3221с41.getBusVoltage(0);
     s3221c41b1a = ina3221с41.getCurrentAmps(0);
     s3221c41b2v = ina3221с41.getBusVoltage(1);
     s3221c41b2a = ina3221с41.getCurrentAmps(1);
     s3221c41b3v = ina3221с41.getBusVoltage(2);
     s3221c41b3a = ina3221с41.getCurrentAmps(2);

     s3221c42b1v = ina3221с42.getBusVoltage(0);
     s3221c42b1a = ina3221с42.getCurrentAmps(0);
     s3221c42b2v = ina3221с42.getBusVoltage(1);
     s3221c42b2a = ina3221с42.getCurrentAmps(1);
     s3221c42b3v = ina3221с42.getBusVoltage(2);
     s3221c42b3a = ina3221с42.getCurrentAmps(2);

     s3221c43b1v = ina3221с43.getBusVoltage(0);
     s3221c43b1a = ina3221с43.getCurrentAmps(0);
     s3221c43b2v = ina3221с43.getBusVoltage(1);
     s3221c43b2a = ina3221с43.getCurrentAmps(1);
     s3221c43b3v = ina3221с43.getBusVoltage(2);
     s3221c43b3a = ina3221с43.getCurrentAmps(2);

    // log();
}
void log(){
    Serial.print("s3221c40b1v ");
    Serial.print(s3221c40b1v);
    Serial.print(" s3221c40b2v ");
    Serial.print(s3221c40b2v);
    Serial.print(" s3221c40b3v ");
    Serial.println(s3221c40b3v);
    Serial.print(" s3221c40b1a");
    Serial.print(s3221c40b1a);
    Serial.print(" s3221c40b2a ");
    Serial.print(s3221c40b2a);
    Serial.print(" s3221c40b31a ");
    Serial.println(s3221c40b3a);

    Serial.print("s3221c41b1v ");
    Serial.print(s3221c41b1v);
    Serial.print(" s3221c41b2v ");
    Serial.print(s3221c41b2v);
    Serial.print(" s3221c41b3v ");
    Serial.println(s3221c41b3v);
    Serial.print(" s3221c41b1a");
    Serial.print(s3221c41b1a);
    Serial.print(" s3221c41b2a ");
    Serial.print(s3221c41b2a);
    Serial.print(" s3221c41b31a ");
    Serial.println(s3221c41b3a);

    Serial.print("s3221c42b1v ");
    Serial.print(s3221c42b1v);
    Serial.print(" s3221c42b2v ");
    Serial.print(s3221c42b2v);
    Serial.print(" s3221c42b3v ");
    Serial.println(s3221c42b3v);
    Serial.print(" s3221c42b1a");
    Serial.print(s3221c42b1a);
    Serial.print(" s3221c42b2a ");
    Serial.print(s3221c42b2a);
    Serial.print(" s3221c42b31a ");
    Serial.println(s3221c42b3a);

    Serial.print("s3221c43b1v ");
    Serial.print(s3221c43b1v);
    Serial.print(" s3221c43b2v ");
    Serial.print(s3221c43b2v);
    Serial.print(" s3221c43b3v ");
    Serial.println(s3221c43b3v);
    Serial.print(" s3221c43b1a");
    Serial.print(s3221c43b1a);
    Serial.print(" s3221c43b2a ");
    Serial.print(s3221c43b2a);
    Serial.print(" s3221c43b31a ");
    Serial.println(s3221c43b3a);

    Serial.print("temperature ");
    Serial.print(temperature);
    Serial.print(" humidity ");
    Serial.print(humidity);
    Serial.print(" pressure ");
    Serial.println(pressure);
}
void getData() {
  Serial.println("Получен запрос");
  getDataTime();
  read_sensor_data();
  jsonDocument.clear();

  add_json_object(103, temperature);
  add_json_object(104, humidity);
  add_json_object(105, pressure);
  
  add_json_object(s3221c40b1name, s3221c40b1v);
  add_json_object(s3221c40b2name, s3221c40b2v);
  add_json_object(s3221c40b3name, s3221c40b3v);

  add_json_object(s3221c41b1name, s3221c41b1v);
  add_json_object(s3221c41b2name, s3221c41b2v);
  add_json_object(s3221c41b3name, s3221c41b3v);

  add_json_object(s3221c42b1name, s3221c42b1v);
  add_json_object(s3221c42b2name, s3221c42b2v);
  add_json_object(s3221c42b3name, s3221c42b3v);

  add_json_object(s3221c43b1name, s3221c43b1v);
  add_json_object(s3221c43b2name, s3221c43b2v);
  add_json_object(s3221c43b3name, s3221c43b3v);
  serializeJson(jsonDocument, buffer);
  // Serial.println((String) "Отправлено: 103:"+temperature+" 104:"+humidity+" 105:"+pressure+" 106:"+s3221c40b1v+" 107:"+s3221c40b2v+" 108:"+s3221c40b3a);
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
  timeClient.forceUpdate();
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
    Serial.println("Инициализация INA3221 на линии I2C 0x40");
  if (!ina3221с40.begin(0x40, &Wire)) { // can use other I2C addresses or buses
    Serial.println("Датчик INA3221 на линии I2C 0x40 не обнаружен");
  }
      Serial.println("Инициализация INA3221 на линии I2C 0x41");
  if (!ina3221с41.begin(0x41, &Wire)) { // can use other I2C addresses or buses
    Serial.println("Датчик INA3221 на линии I2C 0x41 не обнаружен");
  }
        Serial.println("Инициализация INA3221 на линии I2C 0x42");
  if (!ina3221с42.begin(0x42, &Wire)) { // can use other I2C addresses or buses
    Serial.println("Датчик INA3221 на линии I2C 0x42 не обнаружен");
  }
        Serial.println("Инициализация INA3221 на линии I2C 0x43");
  if (!ina3221с43.begin(0x43, &Wire)) { // can use other I2C addresses or buses
    Serial.println("Датчик INA3221 на линии I2C 0x43 не обнаружен");
  }

  ina3221с40.setAveragingMode(INA3221_AVG_16_SAMPLES);
  ina3221с41.setAveragingMode(INA3221_AVG_16_SAMPLES);
  ina3221с42.setAveragingMode(INA3221_AVG_16_SAMPLES);
  ina3221с43.setAveragingMode(INA3221_AVG_16_SAMPLES);
    // Set shunt resistances for all channels to 0.05 ohms
  for (uint8_t i = 0; i < 3; i++) {
    ina3221с40.setShuntResistance(i, 0.05);
    ina3221с41.setShuntResistance(i, 0.05);
    ina3221с42.setShuntResistance(i, 0.05);
    ina3221с43.setShuntResistance(i, 0.05);
  }
  // Set a power valid alert to tell us if ALL channels are between the two
  // limits:
  ina3221с40.setPowerValidLimits(3.0 /* lower limit */, 15.0 /* upper limit */);
  ina3221с41.setPowerValidLimits(3.0 /* lower limit */, 15.0 /* upper limit */);
  ina3221с42.setPowerValidLimits(3.0 /* lower limit */, 15.0 /* upper limit */);
  ina3221с43.setPowerValidLimits(3.0 /* lower limit */, 15.0 /* upper limit */);

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
