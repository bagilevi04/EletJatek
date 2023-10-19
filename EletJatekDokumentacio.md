# Élet játék dokumentáció

Maga a program arra a szabályrendszerre épül, hogy ha az egyik entitás megszűnik létezni akkor **leáll** a szimuláció. 
A program **C#** programozási nyelvben készült, törekszik a **Clean Code** elveire, **objektum orientált**. 

## Szimuláció

**Osztályokra** alapul.

- Állatok (ősoszály)
    1. Róka (leszármazott)
    2. Nyúl (leszármazott)
- Szimuláció

## Felhasznált metódusok:

- Szimuláció osztályban használt metódusok:
    1. `Fu()` - feltölti a mátrixot, mezőként szolgál, frissíti a mátrixban lévő értékeket.
    2. `AllatokAKorben()` - Lefuttatja az összes állatokkal kapcsolatos metódusokat.
- Állatok osztályban használt metódusok:
    1. `Ehezik()` - Körönként csökkenti a jóllakottságát az állatoknak és kezeli, hogyha éhen hal az állat.
    2. `Bekovetkezette()` - Egy segéd metódus, véletlenszerű százalék alapon visszaad egy logikai értéket.
    3. `Meghalt()` - A meghalt állat helyén visszaad egy fűértéket és kiszedi az állatokat kezelő listából a halott állatot.
    4. > Absztrakt metódusok: Eszik(), Mozog(), Szaporodik().
- Róka osztályban használt metódusok:
    - `Eszik()` - Abban az esetben, hogyha az a mátrix mezőn amire át akar lépni, ha tartózkodik rajta nyúl, a nyúl meghal, a fűértékét átveszi és növeli a jóllakottságát hárommal.
    - `Mozog()` - Abban az esetben ha valamelyik szomszédja nyúl, abba az irányba fog mozogni, ellenkező esetben kettőt lép egy véletlenszerű irányba ha ezen a véletlenszerű irányban tartózkodik másik róka, akkor nem lép.
    - `Szaporodik()` - Meghívjuk a Bekovetkezette() metódust, abban az esetben, hogyha bekövetkezik, akkor nem történik semmi, ellenkező esetben megnézi, hogy a szoszédai valmelyik irányban róka e, ha róka, akkor megnézi, hogy valamelyik szomszédos mezője üres-e, ha üres akkor inicializál még egy rókát és az hozzáadódik a mátrixhoz.
    