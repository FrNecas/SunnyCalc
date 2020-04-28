# IVS týmový projekt (kalkulačka) | 2020

## Pracovní skupina Sluníčka | Sunny-Calc 
Členové: František Nečas (**xnecas27**), Ondřej Ondryáš (**xondry02**), David Chocholatý (**xchoch08**) \
Datum: 12. 3. 2020

---
## Komunikace v týmu

#### Komunikační síť
Pro základní komunikaci v týmu slouží Discord server s místnostmi pro obecnou domluvu a strukturovanými místnostmi rozdělenými podle kategorií pro konkrétní otázky.

Využití nestrukturovaného chatu pro řešení aktuální otázky a pravidelné aktualizování pinů v příslušné místnosti pro uchování důležitých a stálých informací. Vytvoření místností pouze pro důležitá oznámení s omezenou možností vedení diskuse.

Správce serveru se stará o udržování serveru a jednotlivých místností po stránce informační i organizační v závislosti na pokroku ve vývoji.

Rozdělení místností podle funkce na:
1. hromadný chat
1. důležitá oznámení a přehled termínů
1. matematická knihovna a ostatní funkce
1. GUI
1. doplňkové služby

Kvůli výjimečnému stavu nařízenému vládou České republiky platícímu na celém území státu není možné organizovat pravidelná osobní setkání na území fakulty pro zhodnocení stávajícího průběhu vývoje a určení následujících kroků, proto jako náhrada bude sloužit *voice chat* na Discord serveru s obdobným průběhem setkání.

Kdyby z jakéhokoliv důvodu nebyla dostupná žádná z předchozích možností komunikace, můžeme se s jednotlivými členy týmu spojit pomocí e-mailů spojených s GitHub účtem nebo případně pomocí fakultních e-mailů, i když je s touto alternativou počítáno pouze jako se záložním řešením, pokud všechny předchozí metody komunikace selžou.

* Každý člen týmu má povinnost minimálně jednou denně kontrolovat aktuální stav projektu na Discord serveru.

#### Systém pro správu verzí a hosting
Pro spolupráci na vývoji využíváme privátní GitHub repozitář. Úprava stávajícího kódu a přidání nového kódu probíhá přes pull requesty, které musí odsouhlasit všichni členové týmu. Pro případ, že bude některý člen týmu dlouhodobě neaktivní či neschopen plnit své povinnosti, zejména při schvalování pull requestů, merge pull requestu lze provést už po jediném schválení od dalšího člena týmu, ale pro standardní situaci je stále vyžadováno potvrzení od všech členů týmu.

* Maximální reakční doba každého člena týmu je 1 den.
* Každý člen týmu má povinnost minimálně jednou denně kontrolovat aktuální stav projektu na GitHubu.

Vykonanou práci sledujeme využitím GitHub issues s uzavíráním hotových částí vývoje.

Průběžná kontrola repozitáře na serveru GitHub zákazníkem bude možná přes [odkaz](https://github.com/FrNecas/IVS-proj2) pomocí kontrolního e-mailu ivs.kontrola@gmail.com.

#### Jazyk
Kód i programová dokumentace kódu je psána anglicky. Rozhraní aplikace česky a uživatelská příručka psána taktéž česky.

---
## Termíny

| Datum | Činnost |
| ----- | ------- |
| 12. 03. | návrh plánu, založení repozitáře na GitHubu a vytvoření komunikačního serveru na Discordu |
| 15. 03. | schválení plánu a rozdělení práce |
| 18. 03. | odevzdání plánu |
| 21. 03. | návrh matematické knihovny pro kalkulačku a vytvoření kostry projektu |
| 23. 03. | sepsání testů pro matematickou knihovnu (rozhraní pro testy knihovny) |
| 24. 03. | Makefile |
| 30. 03. | matematická knihovna |
| 05. 04. | návrh GUI |
| 06. 04. | návrh mockupu |
| 09. 04. | mockup |
| 10. 04. | vytvoření GUI |
| 11. 04. | Beta testování |
| 11. 04. | Doxyfile |
| 12. 04. | vytvoření instalátoru |
| 13. 04. | uživatelská příručka, nápověda |
| 15. 04. | profiling (+ Profile-guided optimization) |
| 20. 04. | revize projektu |
| 21. 04. | odevzdání projektu |
| 24. 04. | individuální hodnocení průběhu vývoje |
| *zkouškové* | instalace u zákazníka |

### V termínech není zahrnuto:
* průběžné testování, které bude probíhat po celou dobu vývoje při výrazné změně kódu a při přidání nové funkcionality,
* dokumentace kódu, kterou budou sepisovat všichni členové týmu zároveň se psaním kódu a která bude průběžně doplňována.

---
## Rozdělení úkolů

* návrh plánu | **společná práce**
    - domluvení základních praktik vývoje
    - rozdělení práce a přidělení úkolů jednotlivým členům
    - sestavení plánu | **xchoch08**
    - zvolení jazyka pro vývoj kalkulačky: C# (.NET Core 3.1) s GUI frameworkem Avalonia

* správa GitHub repozitáře | **xnecas27**
    - vytvoření kostry repozitáře
    - provázání repozitáře s ostatními členy a nastavení oprávnění
    - průběžná kontrola stavu repozitáře
    - řešení GitHub issues a pull requestů

* vytvoření komunikačního serveru na Discordu | **xondry02**
    - rozdělení místností s nastavením příslušných oprávnění
    - správa serveru a kontrola aktualizace oznámení a pinů

* celková kontrola průběhu vývoje a reprezentace týmu pro komunikaci zvenčí | **xchoch08**
    - zajištění dodržování termínů a přerozdělování úkolů jednotlivým členům
    - kontrola plnění povinností členů týmu
    - zajišťování interní komunikace mezi členy týmu
    - komunikace se zákazníkem
    - odevzdání produktu a jeho částí

* vytvoření kostry projektu | **xondry02**
    - základní sestavení struktury projektu pro propojení všech částí
    - provázání knihovny a obslužných funkcí s GUI

* Makefile | **xondry02**
    - nastavení Makefilu pro přeložení programu a zajištění základních operací se zdrojovými kódy

* matematická knihovna | **xchoch08** (výpomoc **xnecas27**)
    - návrh matematické knihovny
    - základní matematické funkce (sčítání, odčítání, násobení, dělení)
    - další matematické funkce (faktoriál, umocňování s přirozenými exponenty, obecná odmocnina)
    - speciální funkce (1 + volitelné další)
    - vyhodnocování výrazů
    - dokumentace kódu

* GUI | **xondry02**
    - návrh GUI
    - implementace GUI a viewmodel vrstvy
    - naprogramování ovládácích prvků kalkulačky a jejich propojení s matematickou knihovnou

* průběžné testování | **xnecas27**
    - ověření funkčnosti částí aplikace
    - test-driven development – testy matematické knihovny
    - testování pokrytí mezních situací a řešení chyb
    - oznámení objevených chyb příslušnému členovi týmu

* Beta testování | **společná práce se zapojením uživatelů**
    - celkové testy vyžadované funkčnosti aplikace
    - zátěžové testy
    - testování a kontrola pokrytí

* Doxyfile | **společná práce**
    - sestavení Doxyfilu pro generování dokumentace
    - vybrání nejlepší verze Doxyfilu pro použití v produktu

* instalátor | **xnecas27, xondry02**
    - spustitelný instalátor aplikace pro Linux a Windows
    - podpora řízené odinstalace aplikace

* profiling | **xchoch08**
    - sestavení samostatného spustitelného programu pro výpočet výběrové směrodatné odchylky
    - využití Profile-guided optimization (PGO)
    - shrnutí efektivity výpočtu a návrh možností optimalizace

* nápověda | **xchoch08**
    - nápověda pro použití aplikace spustitelná přímo z aplikace
    - příklady použití

* zajištění podpory pro zvolené platformy (multiplatformní aplikace)
    - podpora pro Linux | **xnecas27**
    - podpora pro Windows | **xondry02**

* code review | **společná práce**
    - vzájemné kontrolování si kódu
    - revize změn

* dokumentace | **společná práce**
    - programová dokumentace k projektu
    - průběžně sestavovaná členy odpovědnými za danou část kódu
    - sestavení dokumentace a kontrola chyb a nedostatků dokumentace

* uživatelská příručka | **xondry02**
    - návod na instalaci programu
    - podrobný popis funkcí kalkulačky a jejího ovládání

* mockup | **společná práce**
    - mockup uživatelského rozhraní další verze kalkulačky
    - podpora vědeckého módu, vykreslování grafů a další potenciálně užitečné funkce

* revize projektu | **xchoch08**
    - finální kontrola projektu
    - ověření splnění všech podmínek a požadavků zákazníka

* instalace u zákazníka | **společná práce**
    - předvedení produktu u zákazníka
    - ukázka funkcí kalkulačky a práce s ní
    - příprava materiálů pro prezentaci aplikace

* individuální hodnocení průběhu vývoje | **společná práce**

Vedoucí týmu může po odsouhlasení navržené změny všemi členy týmu podle potřeby a aktuální situace přerozdělit úkoly mezi členy jinak, než jak je uvedeno v plánu.

Člen týmu má možnost požádat o změnu činnosti, pozdržení termínu dokončení činnosti či pomoc ze strany ostatích členů týmu, pokud bude možné, že by neúspěch mohl ohrozit vývoj celého produktu. Je na vedoucím týmu, aby zajistil, že všichni členové týmu se budou plně podílet na vývoji a že práce bude rovnoměrně rozložena i při nepředpokládaných překážkách ve vývoji.
