# Order Processing Console Application

## Project Overview
This project is a **console application** for order processing, developed as part of a recruitment process. The application allows creating and managing orders with different statuses and follows specific business rules.

## Task Description (in Polish)
Napisz aplikację konsolową, która umożliwia procesowanie zamówienia.

### Zamówienie może posiadać jeden z 6 statusów:
1. Nowe
2. W magazynie
3. W wysyłce
4. Zwrócono do klienta
5. Błąd
6. Zamknięte

### Aplikacja powinna umożliwiać 5 operacji:
1. Utworzenie przykładowego zamówienia
2. Przekazanie zamówienia do magazynu
3. Przekazanie zamówienia do wysyłki
4. Przegląd zamówień
5. Wyjście

### Zamówienie składa się co najmniej z właściwości:
- Kwota zamówienia
- Nazwa produktu
- Typ klienta (firma, osoba fizyczna)
- Adres dostawy
- Sposób płatności (karta, gotówka przy odbiorze)

### Warunki biznesowe:
- Zamówienia za nie mniej niż 2500 z płatnością gotówką przy odbiorze powinny zostać zwrócone do klienta przy próbie przekazania do magazynu.
- Zamówienia przekazane do wysyłki powinny po co najwyżej 5 sekundach zmienić status na „wysłane”.
- Zamówienia bez adresu wysyłki powinny kończyć się błędem.

Kod powinien zostać opublikowany na GitHubie. Link do rozwiązania prosimy przesłać na adres mailowy osoby prowadzącej rekrutację. Commity powinny umożliwić zrozumienie sposobu myślenia nad rozwiązaniem.

---

## Task Description (in English)
Write a console application that enables order processing.

### An order can have one of six statuses:
1. New
2. In warehouse
3. In shipping
4. Returned to customer
5. Error
6. Closed

### The application should allow five operations:
1. Create a sample order
2. Send the order to the warehouse
3. Send the order to shipping
4. View orders
5. Exit

### An order consists of at least the following properties:
- Order amount
- Product name
- Customer type (company, individual)
- Delivery address
- Payment method (card, cash on delivery)

### Business conditions:
- Orders of at least 2500 with cash on delivery payment should be returned to the customer when attempting to send them to the warehouse.
- Orders sent for shipping should change their status to "shipped" within a maximum of 5 seconds.
- Orders without a shipping address should result in an error.

The code should be published on GitHub. A link to the solution should be sent to the recruitment contact email. Commits should make it possible to understand the thought process behind the solution.
