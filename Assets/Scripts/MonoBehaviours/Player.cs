using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Clase Player que hereda de Character
*/

/*
Nombre: Mario Alberto Rangel Márquez
Descripción: Prototype 4
Fecha: 02/11/2024
*/
public class Player : Character
{
    /*
    * Método invocado cuando otro collider colisiona.
    */
  private void OnTriggerEnter2D(Collider2D collision) 
{
    // Verifica si el objeto colisionado tiene como etiqueta CanBePickedUp
    if (collision.gameObject.CompareTag("CanBePickedUp")) 
    {
        Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

        if (hitObject != null) 
        {
            print("Nombre: " + hitObject.objectName);

            switch (hitObject.itemType) 
            {
                case Item.ItemType.COIN:
                    break;
                case Item.ItemType.HEALTH:
                    AdjustHitPoints(hitObject.quantity);
                    break;
                default:
                    break;
            }
        }

        // Ocultamos el objeto de la escena
        collision.gameObject.SetActive(false);
    }
}

public void AdjustHitPoints(int amount) 
{
    hitPoints = hitPoints + amount;
    print("Ajustando Puntos: " + amount + ". Nuevo Valor: " + hitPoints);
}
}