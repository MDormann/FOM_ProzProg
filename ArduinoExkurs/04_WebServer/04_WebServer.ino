#if defined(ESP8266)
  #include <ESP8266WiFi.h>
  
#elif defined(ESP32)
  #include <WiFi.h>
  
#else
#endif

const char* ssid ="Put SSID Name here";
const char* password ="Put Password here and don't commit to git! :-)";

WiFiServer server(80);

void setup() {
  Serial.begin(9600);
  delay(10);

  Serial.print("Verbinde mit: ");
  Serial.println(ssid);

  WiFi.begin(ssid, password);

  //Warten bis WLAN verbunden ist
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi verbunden");

  //Starten vom WebServer
  server.begin();
  Serial.println("Server started");

  Serial.print("Go to ip:");
  Serial.print("http://");
  Serial.print(WiFi.localIP());
  Serial.println("/");  
}

void loop() {
  
  WiFiClient client = server.available();
  if(!client) {
    return;
  }

  Serial.println("client exists");
  while(!client.available())
  {
   delay (1);
  }

  //read first row of request
  String request = client.readStringUntil('\r');
  Serial.println(request);
  client.flush();


  client.println("HTTP/1.1 200 OK");
  client.println("Content-Type: text/html");
  client.println("");
  client.println("<!DOCTYPE HTML>");
  client.println("<html>");
  client.println("<h1>Hello World!</h1>");
  client.println("</html>");

  delay(1);
  Serial.println("disconnect client!");
  
  
  
}
