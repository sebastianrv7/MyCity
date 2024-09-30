using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static MapManager;


[System.Serializable]
public class Zona
{
        public Foto[] fotos;   // An array that saves all the photos of the area, the photos are classes with various properties
}

[System.Serializable]
public class Foto
{
    public Texture textura;  // The texture where the photo is assigned
    public bool puedeAvanzar;  // This boolean indicates whether you can advance or not
    public int  zonaApuntada;  // This number identifies which area you are viewing.
    
}

public class MapManager : MonoBehaviour
{
    public RawImage rawImage;   // In this Raw Image the photos are assigned

    public Zona[] zonas;  // This is an array that allows you to have the zones you want, add more


    // Here the variables that confirm the area, the photos, are initialized, and if you can advance, they can be assigned directly in the methods, but they change with each movement so it is better to have them like this for better organization and to understand them better, or at least that's how I see it.

    private int currentIndexZone = 0; // Current zone index
    private int currentIndexFoto = 0; // Current photo index
    private bool confirmacionAvanzar; // This boolean confirms whether you can advance or not
    private int indexZonaApuntada;    // Indicator of which areas you are viewing

    
    // The first photo is initialized here, you can change it to start from the area you want

    void Start()
    {

        rawImage.texture = zonas[currentIndexZone].fotos[currentIndexFoto].textura;                 // Here the photo is assigned to raw image for the first time
        confirmacionAvanzar = zonas[currentIndexZone].fotos[currentIndexFoto].puedeAvanzar;         // Here it is assigned for the first time if you can advance from the first photo where you are
        indexZonaApuntada = zonas[currentIndexZone].fotos[currentIndexFoto].zonaApuntada;           // Here you assign for the first time which area you are viewing.
        Debug.Log("Valor de puedeAvanzar: " + confirmacionAvanzar);                                 // This is a debug to see if you can advance
        Debug.Log("Valor de zonaApuntada: " + indexZonaApuntada);                                   // This is a debug to know which area you are looking at

    }



    // This method changes the area where I am to the one you are looking at
    public void CambiarZona()
    {
        if (confirmacionAvanzar == true)                                                             //This method is executed if you can advance from the photo you are in
        {
                     
            currentIndexZone = zonas[currentIndexZone].fotos[currentIndexFoto].zonaApuntada;         // Here you advance and change the area you are seeing

            currentIndexFoto = 0;                                                                    // Here the first photo of the area is assigned to start seeing the area from the first photo of the area
            Debug.Log("ahora estamos en la zona: "+currentIndexZone);                                // This is a debug that tells us which area we are in now
            Debug.Log("ahora estamos en la foto: "+currentIndexFoto);                                // This is a debug that tells us which photo we are in now
            rawImage.texture = zonas[currentIndexZone].fotos[currentIndexFoto].textura;              // Here the photo we are in now is assigned


            confirmacionAvanzar = zonas[currentIndexZone].fotos[currentIndexFoto].puedeAvanzar;      // Here it is assigned whether you can advance from the current photo
            indexZonaApuntada = zonas[currentIndexZone].fotos[currentIndexFoto].zonaApuntada;        // Here you assign which area is being viewed from the current photo.
            Debug.Log("Valor de puedeAvanzar: " + confirmacionAvanzar);                              // This is a debug to see if progress can be made.
            Debug.Log("Valor de zonaApuntada: " + indexZonaApuntada);                                // This is a debuig to know which area you are looking at


        }
        else
        {
            Debug.Log("No se puede avanzar desde aqui");                                             // This is a debug that confirms that you cannot advance from the current photo
        }

    }


    // This is the method to advance through the photos of an area, you just start from the first photo and keep moving forward until you reach the last one, and then you return to the first
    public void WatchZone1()
    {
        currentIndexFoto++;                                                                          //Here you go through the array of photos
        if (currentIndexFoto >= zonas[currentIndexZone].fotos.Length)
        {
            currentIndexFoto = 0;
                        
        }
                                                                                                     // The same assignments are made here as when you change zones.
            rawImage.texture = zonas[currentIndexZone].fotos[currentIndexFoto].textura;
            confirmacionAvanzar = zonas[currentIndexZone].fotos[currentIndexFoto].puedeAvanzar;
            indexZonaApuntada = zonas[currentIndexZone].fotos[currentIndexFoto].zonaApuntada;
            Debug.Log("Valor de puedeAvanzar: " + confirmacionAvanzar);
            Debug.Log("Valor de zonaApuntada: " + indexZonaApuntada);

        
    }
        
    

}
