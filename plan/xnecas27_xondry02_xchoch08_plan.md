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
| 15. 03. | schálení plánu a rozdělení práce |
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