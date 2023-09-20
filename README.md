# PolitiCase

## Case: Politibiler Backend
I denne oppgaven skal du utvikle et backend-system som administrerer politibiler for operasjonssentralen. Du kan velge fritt hvilket språk og rammeverk du vil bruke, men vi ønsker helst at du koder i enten Java, Kotlin eller C#. Løsningen bør bruke et byggverktøy og inneholde tester. Systemet skal eksponeres som et web-API, slik at det kan snakke med en fiktiv frontend.

Oppgaven har ingen fasit og brukes kun i vår dialog sammen i det tekniske intervjuet. Det er lov å gjøre antagelser, men forklar disse i en readme-fil.

## Oppgaven
Du skal implementere et web-API som kan tilby følgende funksjonalitet:

Hente informasjon om en bestemt politibil, inkludert merke, modell, år, registreringsnummer og nåværende status (tilgjengelig, i bruk, under vedlikehold).

Hente en oversikt over alle biler med statusen “Tilgjengelig”. Dataene skal alltid være sortert etter bilenes ID i stigende rekkefølge.

Tildele oppdrag til politibiler (patruljering, nødssituasjoner, spesielle operasjoner, osv.) og oppdatere deres status.

Løsningen din må være i stand til å hente dummy-data direkte fra følgende API: https://politibiler-c6e73455ac85.herokuapp.com
