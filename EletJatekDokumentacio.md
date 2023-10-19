# Élet játék dokumentáció

Maga a program arra a szabályrendszerre épül, hogy ha az egyik entitás megszűnik létezni akkor **leáll** a szimuláció. 
A program **C#** programozási nyelvben készült, törekszik a **Clean Code** elveire, **objektum orientált**. 

## Használati útmutató

- A program indítását követően a szimuláció automatikusan elindul, addig tart ameddig minden állat meg nem hal.
- A kiírásnál látható színek és karakterek:
    - Fű:
        - 0 - ciánkék, 1 - sötétzöld, 2 - világoszöld
    - Róka:
        - R - vörös
    - Nyúl: 
        - N - szürke

## Szimuláció

### Osztályokra alapul.

- Állatok (ősoszály)
    - Róka (leszármazott)
    - Nyúl (leszármazott)
- Szimuláció

## Felhasznált metódusok:

- ***Fő programban*** használt metódusok: 
    - **`Kiiras()`** - Használati útmutatóban említett módon kiírja a mátrixot.
- ***Szimuláció*** osztályban használt metódusok:
    - **`Fu()`** - feltölti a mátrixot, mezőként szolgál, frissíti a mátrixban lévő értékeket.
    - **`AllatokAKorben()`** - Lefuttatja az összes állatokkal kapcsolatos metódusokat.
- ***Állatok*** osztályban használt metódusok:
    - **`Ehezik()`** - Körönként csökkenti a jóllakottságát az állatoknak és kezeli, hogyha éhen hal az állat.
    - `Bekovetkezette()` - Egy segéd metódus, véletlenszerű százalék alapon visszaad egy logikai értéket.
    - **`Meghalt()`** - A meghalt állat helyén visszaad egy fűértéket és kiszedi az állatokat kezelő listából a halott állatot.
    - > Absztrakt metódusok: Eszik(), Mozog(), Szaporodik().
- ***Róka*** osztályban használt metódusok:
    - **`Eszik()`** - Abban az esetben, hogyha az a mátrix mezőn amire át akar lépni, ha tartózkodik rajta nyúl, a nyúl meghal, a fűértékét átveszi és növeli a jóllakottságát hárommal.
    - `Mozog()` - Abban az esetben ha valamelyik szomszédja nyúl, abba az irányba fog mozogni, ellenkező esetben kettőt lép egy véletlenszerű irányba ha ezen a véletlenszerű irányban tartózkodik másik róka, akkor nem lép.
    - **`Szaporodik()`** - Meghívjuk a Bekovetkezette() metódust, abban az esetben, hogyha bekövetkezik, akkor nem történik semmi, ellenkező esetben megnézi, hogy a szomszédai valmelyik irányban róka e, ha róka, akkor megnézi, hogy valamelyik szomszédos mezője üres-e, ha üres akkor inicializál még egy rókát és az hozzáadódik a mátrixhoz.
- ***Nyúl*** osztályban használt metódusok: 
    - **`Eszik()`** - Hogyha átlép egy másik mezőre és a fű értéke 1, akkor a fűérték lenullázódik és továbblép, mindemellett megnő a jóllakottsági szintje egyel, ha a fű értéke 2 akkor a jóllakottsága kettővel nő és a fű értéke felveszi az egyes értéket, más esetben nem eszik a nyúl.
    - **`Mozog()`** - Véletlenszerűen egy szomszédos mezőre lép.
    - **`Szaporodik()`** - Meghívjuk a Bekovetkezette() metódust, abban az esetben, hogyha bekövetkezik, akkor nem történik semmi, ellenkező esetben megnézi, hogy a szomszédai valmelyik irányban nyúl-e, ha nyúl, akkor megnézi, hogy valamelyik szomszédos mezője üres-e, ha üres akkor inicializál még egy nyulat és az hozzáadódik a mátrixhoz.

# Tesztelési terv

- Program futásidő tesztelés:
    - A program addig fut-e, amíg az összes nyúl vagy az összes róka meg nem hal?
- **`Kiiras()`** metódus tesztelés:
    - Ha a mátrix I, J elemén az érték ’0’, akkor a háttérszín DarkCyan-e, majd visszaáll-e ’Black’ színre;
    - Ha a mátrix I, J elemén az érték ’1’, akkor a háttérszín DarkGreen, majd visszaáll-e ’Black’ színre;
    - Ha a mátrix I, J elemén az érték ’2’, akkor a háttérszín Green, majd visszaáll-e ’Black’ színre;
    - Ha a mátrix I, J elemén az érték ’N’, azaz nyúl, akkor a háttérszín Gray, majd visszaáll-e ’Black’ színre;
    - Ha a mátrix I, J elemén az érték ’R’, azaz róka, akkor a háttérszín Red, majd visszaáll-e ’Black’ színre?
- **`Fu()`** metódus tesztelés:
    - Ha a mátrix I, J elemén az érték ’0’, akkor a fű értéke 1 lesz-e;
    - Ha a mátrix I, J elemén az érték ’1’, akkor a fű értéke 2 lesz-e?
- **`Ehezik()`** metódus tesztelés:
    - Minden meghívás esetén csökken-e a ’Jóllakottság’ tulajdonság 1 értékkel-e;
    - Ha ’Jóllakottság’ értéke 0, akkor a ’Halott’ értéke ’true’ lesz-e?
- **`Meghalt()`** metódus tesztelés:
    - Halál esetén a mátrix I, J pontján az érték fűérték lett-e?
- **`Eszik()`** metódus tesztelése (nyúl esetén):
    - Ha a fűnek az értéke 1 vagy 2, akkor a nyúl jóllakottsága nő-e X értékkel, illetve fűérték változik-e?

---

## Projekt név: Élet Játék

### Készítette: Bagi Levente, Furka Dominik, Osztertág Ádám