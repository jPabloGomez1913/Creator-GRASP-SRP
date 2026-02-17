#  Creator (GRASP)

##  Descripción

Este documento explica la aplicación del principio **Creator** de GRASP dentro de un sistema de e-commerce.  
El objetivo es mejorar la asignación de responsabilidades, reducir el acoplamiento y aumentar la cohesión del modelo de dominio.

---

##  Contexto del Sistema

El sistema permite a los clientes realizar órdenes de compra y está compuesto por las siguientes entidades principales:

- **Customer (Cliente)** → Representa a un usuario del sistema.
- **Order (Orden)** → Representa una orden de compra realizada por un cliente.
- **LineItem (Línea de pedido)** → Representa cada producto individual dentro de una orden.
- **Product (Producto)** → Representa un producto disponible en el catálogo.

---

##  Problema Inicial

En el diseño original, la clase `Customer` estaba fuertemente acoplada a múltiples clases del dominio:

        ┌─────────┐
        │Customer │
        └────┬────┘
             │
    ┌────────┼────────┐
    │        │        │
    ▼        ▼        ▼
 Order   LineItem  Product

##  Consecuencias:
- Si cambia la estructura de LineItem, hay que modificar Customer
- Si cambia cómo se agregan items a Order, hay que modificar Customer
- Customer tiene demasiadas dependencias

##  Problemas:
- Order no puede validar los LineItems que se agregan
- No hay control sobre cómo se construyen los items
- La lógica de negocio está dispersa


## Solución planteada

Para la solución se decidio aplicar un DDD(DOMAIN DRIVE DESIGN)





        ┌──────────┐
        │ Customer │
        └────┬─────┘
             │ Crea
             ▼
         ┌───────┐          ┌─────────┐
         │ Order │◄─────────│ Product │
         └───┬───┘  Recibe  └─────────┘
             │      como
             │      parámetro
             │      y accede
             │      directamente
             │
             │ Usa product.Id
             │ Usa product.Price
             │ Crea
             ▼
        ┌──────────┐
        │ LineItem │
        └──────────┘
        
        



## Decisiones

- Setter privado para que la entidad controla CÓMO se modifican sus propiedades
- Se usa un Factory Method para que  solo pueden crearse a través de sus métodos Register() y evitar la aparicion de new() por todas partes

## Beneficios:

- Customer solo depende de Order
- Customer NO conoce LineItem (desacoplado)
- Si LineItem cambia, solo afecta a Order
- Menor propagación de cambios

-------------------------------------------------

#  Single Responsibility Principe (SRP)

## Descripción

Adicionalmente, en esta sección del documento se explicará la aplicación del principio **SRP (Single Responsability Principe** dentro del sistema e-commerce utilizado.
El objetivo es asegurar que cada clase tenga una única razón para cambiar, mejorando la mantenibilidad y optimizando el acoplamiento del sistema.

---

## Contenido del sistema

El sistema permite a los clientes realizar órdenes de compra y está compuesto por las siguientes entidades principales:

- **Customer (Cliente)** → Representa a un usuario del sistema.
- **Order (Orden)** → Representa una orden de compra realizada por un cliente.
- **LineItem (Línea de pedido)** → Representa cada producto individual dentro de una orden.
- **Product (Producto)** → Representa un producto disponible en el catálogo.

---

## Problema inicial

En el diseño original, las clases tenían múltiples responsabilidades, violando el principio SRP:

        ┌──────────────────────────────────────┐
        │           Customer                   │
        ├──────────────────────────────────────┤
        │ - Crear órdenes                      │
        │ - Gestionar Datos                    │
        └──────────────────────────────────────┘
        ┌──────────────────────────────────────┐
        │           Product                    │
        ├──────────────────────────────────────┤
        │ - ActualizarStock                    │
        │ - SolicitarUnidades                  │
        │ - EnviarEmailProveedor               │
        └──────────────────────────────────────┘

## Consecuencias

- Si cambia el proceso de creación de productos, hay que modificar Customer
- Si cambia la lógica de la actualización del stock, hay que actualizar producto
- Si cambia el proceso de envío de notificaciones al proveedor, hay que modificar Product

## Problemas

- Las clases hacen cosas no relacionadas
- Depende de múltiples subsistemas
- Un cambio puede romper múltiples funcionalidades
- No se puede usar una funcionalidad sin las demás

## Aplicación de los principios

## Solución planteada

Para la solución se decidió aplicar SRP separando responsabilidades en clases especializadas:

        ┌─────────────┐
        │  Customer   │  → Solo registra los clientes y crea las órdenes
        └─────────────┘
        
        ┌─────────────────────────┐
        │    CustomerService      │  → Solo gestiona los datos del cliente
        └─────────────────────────┘
        
        ┌─────────────┐
        │    Order    │  → Solo gestiona las órdenes (creadas por Customer)
        └─────────────┘
        
        ┌─────────────────────────┐
        │    InventoryManager     │  → Solo gestiona el manejo del inventario
        └─────────────────────────┘

## Decisiones

- Se decidió optar por que customer solo registre clientes y cree órdenes
- Los cálculos realizados dentro de Order se realizan dentro de su propia clase
- Productos se enfoca en su propia información
- Se separa la gestión de inventarios

## Beneficios:

- Se mejora la relación y cohesión entre las funcionalidades de las clases
- Se reducen las dependencias entre clases 
- Mejor mantenibilidad y testeabilidad
- Facilita la aplicación de otros principios
