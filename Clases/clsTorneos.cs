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
  }
}