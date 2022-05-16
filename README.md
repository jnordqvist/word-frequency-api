# word-frequency-api

Klona repot och öppna projektet. Starta projektet och låt det köra i bakgrunden. 

klistra in kommandot här under i kommandotolken, ersätt PORTNR med det portnummer som visas i addressfältet i webbläsaren, ersätt TEXT med den text du vill räkna ord i.

``
curl -H "Content-type: text/plain" -X "POST" -d "TEXT" https://localhost:PORTNR/count
``
