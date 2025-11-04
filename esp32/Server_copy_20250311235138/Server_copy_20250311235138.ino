#include <WiFi.h>
#include <Wire.h>
#include <NetworkClient.h>
#include <WebServer.h>
#include <ESPmDNS.h>
#include <Adafruit_Sensor.h>
// #include <Adafruit_BME280.h>
#include <Adafruit_INA3221.h>
#include "Adafruit_BusIO_Register.h"
#include <ArduinoJson.h>
// #include <NTPClient.h>
// #include <WiFiUdp.h>
#include <LiquidCrystal_I2C.h>

//settings
//const char *ssid = "RT-GPON-3C30";
//const char *password = "1q2w3e4r5t";
const char *ssid = "RiiVaazZol";
const char *password = "24052000rvz";
// const char *ssid = "Atom_209";
// const char *password = "atomenergetik";
//const char *ssid = "qiwixe";
//const char *password = "1q2w3e4r5t";

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

// WiFiUDP ntpUDP;
// NTPClient timeClient(ntpUDP);

String formattedDate;
String dayStamp;
String timeStamp;

// Adafruit_BME280 bme;
Adafruit_INA3221 ina3221c40;
Adafruit_INA3221 ina3221c41;
Adafruit_INA3221 ina3221c42;
Adafruit_INA3221 ina3221c43;
String JSON;
LiquidCrystal_I2C lcd(0x27, 16, 2);

// float temperature;
// float humidity;
// float pressure;
double s3221c40b1v[3];
double s3221c40b2v[3];
double s3221c40b3v[3];
double s3221c40b1a[3];
double s3221c40b2a[3];
double s3221c40b3a[3];

double s3221c40b1vAVG;
double s3221c40b2vAVG;
double s3221c40b3vAVG;
double s3221c40b1aAVG;
double s3221c40b2aAVG;
double s3221c40b3aAVG;

double s3221c41b1v[3];
double s3221c41b2v[3];
double s3221c41b3v[3];
double s3221c41b1a[3];
double s3221c41b2a[3];
double s3221c41b3a[3];

double s3221c41b1vAVG;
double s3221c41b2vAVG;
double s3221c41b3vAVG;
double s3221c41b1aAVG;
double s3221c41b2aAVG;
double s3221c41b3aAVG;

double s3221c42b1v[3];
double s3221c42b2v[3];
double s3221c42b3v[3];
double s3221c42b1a[3];
double s3221c42b2a[3];
double s3221c42b3a[3];

double s3221c42b1vAVG;
double s3221c42b2vAVG;
double s3221c42b3vAVG;
double s3221c42b1aAVG;
double s3221c42b2aAVG;
double s3221c42b3aAVG;

double s3221c43b1v[3];
double s3221c43b2v[3];
double s3221c43b3v[3];
double s3221c43b1a[3];
double s3221c43b2a[3];
double s3221c43b3a[3];

double s3221c43b1vAVG;
double s3221c43b2vAVG;
double s3221c43b3vAVG;
double s3221c43b1aAVG;
double s3221c43b2aAVG;
double s3221c43b3aAVG;

StaticJsonDocument<1500> jsonDocument;
char buffer[1500];

WebServer server(80);
void add_json_object(int Sensor, float value) {
  JsonObject obj = jsonDocument.createNestedObject();
  obj["Sensor_id"] = Sensor;
  obj["Station_id"] = 7;
  obj["Date_of_m"] = dayStamp; 
  obj["Time_of_m"] = timeStamp; 
  obj["Value_of_m"] = value; 
}
float getMedian(double *values, int size) {
  // Копируем массив, чтобы не менять оригинал
  float sorted[size];
  for (int i = 0; i < size; i++) {
    sorted[i] = values[i];
  }

  // Простая сортировка (пузырьком, для малых массивов — достаточно)
  for (int i = 0; i < size - 1; i++) {
    for (int j = i + 1; j < size; j++) {
      if (sorted[i] > sorted[j]) {
        float temp = sorted[i];
        sorted[i] = sorted[j];
        sorted[j] = temp;
      }
    }
  }
    return sorted[1];
}
void read_sensor_data() {
    //  temperature = bme.readTemperature();
    //  humidity = bme.readHumidity();
    //  pressure = bme.readPressure() / 100 * 0.7500615;
    for (int i=0; i < 3; i++){
     s3221c40b1v[i] = ina3221c40.getBusVoltage(0);
     s3221c40b1a[i] = ina3221c40.getCurrentAmps(0);
     s3221c40b2v[i] = ina3221c40.getBusVoltage(1);
     s3221c40b2a[i] = ina3221c40.getCurrentAmps(1);
     s3221c40b3v[i] = ina3221c40.getBusVoltage(2);
     s3221c40b3a[i] = ina3221c40.getCurrentAmps(2);

     s3221c41b1v[i] = ina3221c41.getBusVoltage(0);
     s3221c41b1a[i] = ina3221c41.getCurrentAmps(0);
     s3221c41b2v[i] = ina3221c41.getBusVoltage(1);
     s3221c41b2a[i] = ina3221c41.getCurrentAmps(1);
     s3221c41b3v[i] = ina3221c41.getBusVoltage(2);
     s3221c41b3a[i] = ina3221c41.getCurrentAmps(2);

     s3221c42b1v[i] = ina3221c42.getBusVoltage(0);
     s3221c42b1a[i] = ina3221c42.getCurrentAmps(0);
     s3221c42b2v[i] = ina3221c42.getBusVoltage(1);
     s3221c42b2a[i] = ina3221c42.getCurrentAmps(1);
     s3221c42b3v[i] = ina3221c42.getBusVoltage(2);
     s3221c42b3a[i] = ina3221c42.getCurrentAmps(2);

     s3221c43b1v[i] = ina3221c43.getBusVoltage(0);
     s3221c43b1a[i] = ina3221c43.getCurrentAmps(0);
     s3221c43b2v[i] = ina3221c43.getBusVoltage(1);
     s3221c43b2a[i] = ina3221c43.getCurrentAmps(1);
     s3221c43b3v[i] = ina3221c43.getBusVoltage(2);
     s3221c43b3a[i] = ina3221c43.getCurrentAmps(2);
     delay(100);
    }

    s3221c40b1vAVG = getMedian(s3221c40b1v,3);
    s3221c40b2vAVG = getMedian(s3221c40b2v,3);
    s3221c40b3vAVG = getMedian(s3221c40b3v,3);
    s3221c40b1aAVG = getMedian(s3221c40b1a,3);
    s3221c40b2aAVG = getMedian(s3221c40b2a,3);
    s3221c40b3aAVG = getMedian(s3221c40b3a,3);

    s3221c41b1vAVG = getMedian(s3221c41b1v,3);
    s3221c41b2vAVG = getMedian(s3221c41b2v,3);
    s3221c41b3vAVG = getMedian(s3221c41b3v,3);
    s3221c41b1aAVG = getMedian(s3221c41b1a,3);
    s3221c41b2aAVG = getMedian(s3221c41b2a,3);
    s3221c41b3aAVG = getMedian(s3221c41b3a,3);
    
    s3221c42b1vAVG = getMedian(s3221c42b1v,3);
    s3221c42b2vAVG = getMedian(s3221c42b2v,3);
    s3221c42b3vAVG = getMedian(s3221c42b3v,3);
    s3221c42b1aAVG = getMedian(s3221c42b1a,3);
    s3221c42b2aAVG = getMedian(s3221c42b2a,3);
    s3221c42b3aAVG = getMedian(s3221c42b3a,3);
    
    s3221c43b1vAVG = getMedian(s3221c43b1v,3);
    s3221c43b2vAVG = getMedian(s3221c43b2v,3);
    s3221c43b3vAVG = getMedian(s3221c43b3v,3);
    s3221c43b1aAVG = getMedian(s3221c43b1a,3);
    s3221c43b2aAVG = getMedian(s3221c43b2a,3);
    s3221c43b3aAVG = getMedian(s3221c43b3a,3);
    
    log();
}
void log(){
    Serial.print("s3221c40b1v ");
    Serial.print(s3221c40b1vAVG);
    Serial.print(" s3221c40b2v ");
    Serial.print(s3221c40b2vAVG);
    Serial.print(" s3221c40b3v ");
    Serial.println(s3221c40b3vAVG);
    Serial.print(" s3221c40b1a");
    Serial.print(s3221c40b1aAVG);
    Serial.print(" s3221c40b2a ");
    Serial.print(s3221c40b2aAVG);
    Serial.print(" s3221c40b31a ");
    Serial.println(s3221c40b3aAVG);

    Serial.print("s3221c41b1v ");
    Serial.print(s3221c41b1vAVG);
    Serial.print(" s3221c41b2v ");
    Serial.print(s3221c41b2vAVG);
    Serial.print(" s3221c41b3v ");
    Serial.println(s3221c41b3vAVG);
    Serial.print(" s3221c41b1a");
    Serial.print(s3221c41b1aAVG);
    Serial.print(" s3221c41b2a ");
    Serial.print(s3221c41b2aAVG);
    Serial.print(" s3221c41b31a ");
    Serial.println(s3221c41b3aAVG);

    Serial.print("s3221c42b1v ");
    Serial.print(s3221c42b1vAVG);
    Serial.print(" s3221c42b2v ");
    Serial.print(s3221c42b2vAVG);
    Serial.print(" s3221c42b3v ");
    Serial.println(s3221c42b3vAVG);
    Serial.print(" s3221c42b1a");
    Serial.print(s3221c42b1aAVG);
    Serial.print(" s3221c42b2a ");
    Serial.print(s3221c42b2aAVG);
    Serial.print(" s3221c42b31a ");
    Serial.println(s3221c42b3aAVG);

    Serial.print("s3221c43b1v ");
    Serial.print(s3221c43b1vAVG);
    Serial.print(" s3221c43b2v ");
    Serial.print(s3221c43b2vAVG);
    Serial.print(" s3221c43b3v ");
    Serial.println(s3221c43b3vAVG);
    Serial.print(" s3221c43b1a");
    Serial.print(s3221c43b1aAVG);
    Serial.print(" s3221c43b2a ");
    Serial.print(s3221c43b2aAVG);
    Serial.print(" s3221c43b31a ");
    Serial.println(s3221c43b3aAVG);

    // Serial.print("temperature ");
    // Serial.print(temperature);
    // Serial.print(" humidity ");
    // Serial.print(humidity);
    // Serial.print(" pressure ");
    // Serial.println(pressure);
}
void getData() {
  Serial.println("Получен запрос");
  // getDataTime();
  read_sensor_data();
  jsonDocument.clear();

  // add_json_object(103, temperature);
  // add_json_object(104, humidity);
  // add_json_object(105, pressure);
  
  add_json_object(s3221c40b1name, s3221c40b1vAVG);
  add_json_object(s3221c40b2name, s3221c40b2vAVG);
  add_json_object(s3221c40b3name, s3221c40b3vAVG);

  add_json_object(s3221c41b1name, s3221c41b1vAVG);
  add_json_object(s3221c41b2name, s3221c41b2vAVG);
  add_json_object(s3221c41b3name, s3221c41b3vAVG);

  add_json_object(s3221c42b1name, s3221c42b1vAVG);
  add_json_object(s3221c42b2name, s3221c42b2vAVG);
  add_json_object(s3221c42b3name, s3221c42b3vAVG);

  add_json_object(s3221c43b1name, s3221c43b1vAVG);
  add_json_object(s3221c43b2name, s3221c43b2vAVG);
  add_json_object(s3221c43b3name, s3221c43b3vAVG);
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
// void getDataTime() {
//   timeClient.forceUpdate();
//   formattedDate = timeClient.getFormattedDate();
//   int splitT = formattedDate.indexOf("T");
//   dayStamp = formattedDate.substring(0, splitT);
//   timeStamp = formattedDate.substring(splitT+1, formattedDate.length()-1);
// }
void setup(void) {
  Serial.begin(115200);
  delay(1000);

  // // Initialize the BME280
  // Serial.println("Инициализация BME280");
  // if (!bme.begin(0x76)) {
  //   Serial.println("Датчик BME280 не обнаружен!");
  // }
  // Initialize the INA3221
    Serial.println("Инициализация INA3221 на линии I2C 0x40");
  if (!ina3221c40.begin(0x40, &Wire)) { // can use other I2C addresses or buses
    Serial.println("Датчик INA3221 на линии I2C 0x40 не обнаружен");
  }
      Serial.println("Инициализация INA3221 на линии I2C 0x41");
  if (!ina3221c41.begin(0x41, &Wire)) { // can use other I2C addresses or buses
    Serial.println("Датчик INA3221 на линии I2C 0x41 не обнаружен");
  }
        Serial.println("Инициализация INA3221 на линии I2C 0x42");
  if (!ina3221c42.begin(0x42, &Wire)) { // can use other I2C addresses or buses
    Serial.println("Датчик INA3221 на линии I2C 0x42 не обнаружен");
  }
        Serial.println("Инициализация INA3221 на линии I2C 0x43");
  if (!ina3221c43.begin(0x43, &Wire)) { // can use other I2C addresses or buses
    Serial.println("Датчик INA3221 на линии I2C 0x43 не обнаружен");
  }

  ina3221c40.setAveragingMode(INA3221_AVG_16_SAMPLES);
  ina3221c41.setAveragingMode(INA3221_AVG_16_SAMPLES);
  ina3221c42.setAveragingMode(INA3221_AVG_16_SAMPLES);
  ina3221c43.setAveragingMode(INA3221_AVG_16_SAMPLES);
    // Set shunt resistances for all channels to 0.05 ohms
  for (uint8_t i = 0; i < 3; i++) {
    ina3221c40.setShuntResistance(i, 0.05);
    ina3221c41.setShuntResistance(i, 0.05);
    ina3221c42.setShuntResistance(i, 0.05);
    ina3221c43.setShuntResistance(i, 0.05);
  }
  // Set a power valid alert to tell us if ALL channels are between the two
  // limits:
  ina3221c40.setPowerValidLimits(3.0 /* lower limit */, 15.0 /* upper limit */);
  ina3221c41.setPowerValidLimits(3.0 /* lower limit */, 15.0 /* upper limit */);
  ina3221c42.setPowerValidLimits(3.0 /* lower limit */, 15.0 /* upper limit */);
  ina3221c43.setPowerValidLimits(3.0 /* lower limit */, 15.0 /* upper limit */);

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

  // timeClient.begin();
  // timeClient.setTimeOffset(18000);
Wire.beginTransmission(0x27);
if (Wire.endTransmission() == 0) {
  // Включение экрана
  lcd.init();
  lcd.backlight();
  lcd.setCursor(0, 0);
  lcd.print("Local IP:");
  lcd.setCursor(0, 1);
  lcd.print(WiFi.localIP());
  Serial.println("LCD найден на 0x27");
} else {
  Serial.println("LCD не найден — пропуск инициализации");
}
}

void loop(void) {
  server.handleClient();
  delay(2);  //allow the cpu to switch to other tasks
}
