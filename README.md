# casinoMasivian
Prueba técnica Masivian aplicando las directrices de Clean Code.

## Punto 1.

- Requerimiento: Crear nuevas ruletas. 
- Método: GET
- Path : http://localhost:5000/casino/createRoulette
- Return: (int) id ruleta nueva. 

## Punto 2

- Requerimiento: Apertura de ruletas. 
- Método: GET
- Parámetros: {id} = id ruleta 
- Path : http://localhost:5000/casino/OpenRoulette/{id}
- Return: (String) Confirmación de apertura.  

## Punto 3

- Requerimiento: Creación de apuestas con las validaciones correspondientes.
- Método: POST
- Body: 
{ 
  "IdRoulette":1,
  "color":null,
  "number":12,
  "amount":500
}
- Headers: userId: {id} 
- Parámetros: {id} = id ruleta 
- Path : http://localhost:5000/casino/createBet/{id}
- Return: (String) Confirmación de la creación de la apuesta o mensaje de validación.
- Notas: En el body si se envía "color", el párametro "number" irá null y se se envía "number", "color" irá null. 

## Punto 4

- Requerimiento: Cierre de ruletas y retorno de los resultados 
- Método: GET
- Parámetros: {id} = id ruleta 
- Path : http://localhost:5000/casino/getRoulettes
- Return: (json) Confirmación de la creación de la apuesta o mensaje de valicación 
- Ejemplo  return: 

{
"idRoulette": 1,
"color": "negro",
"number": null,
"amount": 500,
"profits": 0,
"userId": 1
},
{
"idRoulette": 1,
"color": null,
"number": 12,
"amount": 500,
"profits": 2500,
"userId": 1
}

## Punto 5

- Requerimiento: Listado de ruletas creadas con sus estados
- Método: GET
- Path : http://localhost:5000/casino/getRoulettes
- Return: (json)Listado de ruletas creadas con sus estados
- Ejemplo  return: 
{"id":1,"isOpen":false},{"id":2,"isOpen":false},{"id":3,"isOpen":false}








