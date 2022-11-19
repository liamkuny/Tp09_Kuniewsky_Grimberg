namespace Tp09_Kuniewsky_Grimberg.Models;
using System;

public class Monumento
{
     private int _IdMonumentos, _IdCategoria;
    private string _nombre, _foto, _barrio, _infoLugar;
    private DateTime _fechaFundacion;


    public int IdMonumento
    {
        get { return _IdMonumentos; }
        set { _IdMonumentos = value; }
    }

     public int IdCategoria
    {
        get { return _IdCategoria; }
        set { _IdCategoria = value; }
    }

    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    public string Foto
    {
        get { return _foto; }
        set { _foto = value; }
    }

    public string Barrio
    {
        get { return _barrio; }
        set { _barrio = value; }
    }

    public string Info
    {
        get { return _infoLugar; }
        set { _infoLugar = value; }
    }

    public DateTime FechaFundacion
    {
        get { return _fechaFundacion; }
        set { _fechaFundacion = value; }
    }
}