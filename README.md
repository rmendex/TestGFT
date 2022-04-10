<h1>Test GFT</h1>

<b>Backend Requirements</b>
1. Create this solution as a web API application
2. Solution must have unit tests
3. Push your solution in a GitHub repository, and send us a link when done

<b>Rules</b>
1. You must enter time of day as “morning” or “night”
2. You must enter a comma delimited list of dish types with at least one selection
3. The output must print food in the following order: entrée, side, drink, dessert
4. There is no dessert for morning meals
5. Input is not case sensitive
6. If invalid selection is encountered, display valid selections up to the error, then print error
7. In the morning, you can order multiple cups of coffee
8. At night, you can have multiple orders of potatoes
9. Except for the above rules, you can only order 1 of each dish type


</br>

<i>Aplicação API utiliza CodeFirst</i>

</br>

<b>EndPoint [POST]: /api/OrderMenu/v1/meals</b>

</br>

<b>Sample Input and Output:</b>
1. Input: morning, 1, 2, 3 Output: eggs, toast, coffee
2. Input: morning, 2, 1, 3 Output: eggs, toast, coffee
3. Input: morning, 1, 2, 3, 4 Output: eggs, toast, coffee, error
4. Input: morning, 1, 2, 3, 3, 3 Output: eggs, toast, coffee(x3)
5. Input: night, 1, 2, 3, 4 Output: steak, potato, wine, cake
6. Input: night, 1, 2, 2, 4 Output steak, potato(x2), cake
7. Input: night, 1, 2, 3, 5 Output: steak, potato, wine, error
8. Input: night, 1, 1, 2, 3, 5 Output: steak, error


# Json - POST
```
             POST /api/OrderMenu/v1/meals
             {
                "TimeOfDay": "morning",
                "DishType": [1,2,3]
             }
```


