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

## Aplicación de los principios

## Solción planteada

Para la solución se decidio aplicar un DDD(DOMAIN DRIVE DESIGN)

# #Desiciones
- Se decidio agregar constructores privados para evitar creación descontrolada, por el contrario se expusieron metodos estaticos
- Setter privado para que la entidad controla CÓMO se modifican sus propiedades
     ┌─────────┐
    │Customer │
    └────┬────┘
         │
         │ Solo conoce Order
         ▼
     ┌───────┐
     │ Order │
     └───┬───┘
         │
         │ Solo conoce LineItem y Product
         ├────────┐
         ▼        ▼
    LineItem   Product



## Beneficios:

- Customer solo depende de Order
- Customer NO conoce LineItem (desacoplado)
- Si LineItem cambia, solo afecta a Order
- Menor propagación de cambios


