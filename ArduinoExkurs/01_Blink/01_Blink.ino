//Dieses Skript definiert den LED_BUILTIN Pin als Output und lässt ihn im Anschluss im Sekundentakt blinken.

void setup() {
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop() {
  digitalWrite(LED_BUILTIN, HIGH);
  delay(1000);
  digitalWrite(LED_BUILTIN, LOW);
  delay(1000);
}
