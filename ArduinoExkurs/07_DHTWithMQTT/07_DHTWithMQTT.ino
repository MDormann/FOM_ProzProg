#if defined(ESP8266)
  #include <ESP8266WiFi.h>
  #include <ESP8266WiFiClient.h>
  #include <ESP8266WebServer.h>

  ESP8266WiFiClient wifiClient;
  ESP8266WebServer server(80);

#elif defined(ESP32)
  #include <WiFi.h>
  #include <WiFiClient.h>
  #include <WebServer.h>

  WiFiClient wifiClient;
  WebServer server(80);  
#endif

#include <DHT.h>
#include <DHT_U.h>
#define DHTPIN 2 //ESP8266 Pin D4 / ESP32 Pin G2
#define DHTTYPE DHT11
DHT dht(DHTPIN, DHTTYPE);

#include <PubSubClient.h>

// Add your MQTT Broker IP address, example:
const char* mqtt_server = "192.168.18.114";
PubSubClient mqttClient(wifiClient);
long lastMsg = 0;
char msg[50];
int value = 0;
String clientId = "my-fancy-esp-clientid-";

#include <WiFiManager.h>

//const char* ssid = "REPLACE_WITH_YOUR_SSID";
//const char* password = "REPLACE_WITH_YOUR_PASSWORD";

void handleRoot();
void handleTemp();

float temperature = 0;
float humidity = 0;

void setup() {
  WiFi.mode(WIFI_STA);
  
  Serial.begin(9600);
  delay(10);

//  Serial.print("Verbinde mit: ");
//  Serial.println(ssid);

//  WiFi.begin(ssid, password);
//
//  //Warten bis WLAN verbunden ist
//  while (WiFi.status() != WL_CONNECTED) {
//    delay(500);
//    Serial.print(".");
//  }

  WiFiManager wifiManager;
  wifiManager.autoConnect();

  Serial.println("");
  Serial.println("WiFi verbunden");

  server.on("/", handleRoot);
  server.on("/temp", handleTemp);
  //Starten vom WebServer
  server.begin();
  
  Serial.println("Server started");

  Serial.print("Go to ip:");
  
  Serial.print("http://");
  Serial.print(WiFi.localIP());
  Serial.println("/");

  Serial.println("Welcome to the simple DHT WebServer!");

  dht.begin();

  mqttClient.setServer(mqtt_server, 1883);
  mqttClient.setCallback(callback);
  clientId += String(random(0xffff), HEX);
  
}

void handleRoot(){
  server.send(200, "text/html", "<html><body><h1>hello world</h1></body></html>");
}

void handleTemp(){
  server.send(200, "text/plain", String(temperature).c_str());
}

void loop() {
  server.handleClient();

  if(!mqttClient.connected())
  {
    reconnect();
  }
  //process incoming messages / publish data / refresh connection
  mqttClient.loop();
  
  delay(1000);

  //With real DHT
  //humidity = dht.readHumidity();
  //temperature = dht.readTemperature();

  //Without real DHT
  humidity = readHumidity();
  temperature = readTemperature();

  if (isnan(humidity) || isnan(temperature)) {
    return;
  }

  Serial.print(F("Humidity: "));
  Serial.print(humidity);
  Serial.print(F("%  Temperature: "));
  Serial.print(temperature);
  Serial.print(F("°C "));
  Serial.println("");

  char tempString[8];
  mqttClient.publish((clientId + "/temperature").c_str(), dtostrf(temperature, 1,2, tempString));
  mqttClient.publish((clientId + "/humidity").c_str(), dtostrf(humidity, 1,2, tempString));

}

float readHumidity()
{
  float value = 100;

  return random(5000,  6500) / value;
}

float readTemperature()
{
  float value = 100;
  return random(1900,  2300) / value;
}

void callback(char* topic, byte* payload, unsigned int length) 
{
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  for (int i = 0; i < length; i++) {
    Serial.print((char)payload[i]);
  }
  Serial.println();
}

void reconnect() 
{
  while(!mqttClient.connected())
  {
    Serial.print("Attempting MQTT connection...");
    if(mqttClient.connect(clientId.c_str()))
    {
      Serial.println("connected");
      mqttClient.publish((clientId + "/status").c_str(), "hello world");
    } else {
      Serial.print("failed, rc=");
      Serial.print(mqttClient.state());
      Serial.println(" next try in 5 seconds");
      delay(5000);
    }
  }
}
