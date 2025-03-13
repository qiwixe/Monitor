#include <WiFi.h>
#include <Wire.h>
#include <NetworkClient.h>
#include <WebServer.h>
#include <ESPmDNS.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BME280.h>
#include <ArduinoJson.h>
#include <NTPClient.h>
#include <WiFiUdp.h>

WiFiUDP ntpUDP;
NTPClient timeClient(ntpUDP);

String formattedDate;
String dayStamp;
String timeStamp;

Adafruit_BME280 bme;
String JSON;
const char *ssid = "RT-GPON-3C30";
const char *password = "1q2w3e4r5t";
float temperature;
float humidity;
float pressure;

StaticJsonDocument<400> jsonDocument;
char buffer[400];

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
}
void getData() {
  Serial.println("Get BME280 Sensor Data");
  getDataTime();
  read_sensor_data();
  jsonDocument.clear();
  add_json_object(103, temperature);
  add_json_object(104, humidity);
  add_json_object(105, pressure);
  serializeJson(jsonDocument, buffer);
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
  Serial.println("Инициализация BME280");
  if (!bme.begin(0x76)) {
    Serial.println("Could not find a valid BME280 sensor, check wiring!");
    while (1);
  }

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
