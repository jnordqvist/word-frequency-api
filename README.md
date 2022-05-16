# word-frequency-api

Klona repot och öppna projektet. Starta projektet i visual studio e.dyl. och låt det köra i bakgrunden. 

Klistra in kommandot här under i kommandotolken, ersätt PORTNR med det portnummer som visas i addressfältet i webbläsaren, ersätt TEXT med den text du vill räkna ord i.

``
curl -H "Content-type: text/plain" -X "POST" -d "TEXT" https://localhost:PORTNR/count
``
