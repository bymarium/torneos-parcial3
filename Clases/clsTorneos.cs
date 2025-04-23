using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using torneos.Models;

namespace torneos.Clases
{
  public class clsTorneos
  {
    private DBExamenEntities dbExamen = new DBExamenEntities();
    public Torneo torneo { get; set; }

    public string Guardar()
    {
      try
      {
        dbExamen.Torneos.Add(torneo);
        dbExamen.SaveChanges();
        return "¡Torneo guardado exitosamente";
      }
      catch (Exception ex)
      {
        return "Error al guardar el torneo: " + ex.Message;
      }
    }

    public string Actualizar(int idTorneo, Torneo nuevosDatos)
    {
      try
      {
        Torneo torneo = dbExamen.Torneos.FirstOrDefault(e => e.idTorneos == idTorneo);
        if (torneo == null)
        {
          return "No se encontró un torneo con id: " + idTorneo;
        }

        torneo.TipoTorneo = nuevosDatos.TipoTorneo;
        torneo.NombreTorneo = nuevosDatos.NombreTorneo;
        torneo.NombreEquipo = nuevosDatos.NombreEquipo;
        torneo.ValorInscripcion = nuevosDatos.ValorInscripcion;
        torneo.FechaTorneo = nuevosDatos.FechaTorneo;
        torneo.Integrantes = nuevosDatos.Integrantes;

        dbExamen.SaveChanges();
        return "¡Torneo actualizado exitosamente!";
      }
      catch (Exception ex)
      {
        return "Error al actualizar el torneo: " + ex.Message;
      }
    }

    public string Eliminar(int idTorneo)
    {
      try
      {
        Torneo torneo = dbExamen.Torneos.FirstOrDefault(e => e.idTorneos == idTorneo);

        if (torneo == null)
        {
          return "No se encontro torneo con id: " + idTorneo;
        }

        dbExamen.Torneos.Remove(torneo);
        dbExamen.SaveChanges();

        return "¡Torneo eliminado exitosamente!";
      }
      catch (Exception ex)
      {
        return "Error al eliminar el torneo: " + ex.Message;
      }
    }
  }
}