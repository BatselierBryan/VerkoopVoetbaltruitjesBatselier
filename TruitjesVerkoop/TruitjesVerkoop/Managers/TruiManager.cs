using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model;

namespace BusinessLayer.Managers
{
    public class TruiManager
    {
        public void VoegTruitjeToe(Trui t)
        {

        }
        public void VerwijderTruitje(Trui t)
        {

        }
        public void UpdateTruitje(Trui t)
        {
            try
            {
                if (repo.Bestaattrui(trui.id)
                {
                    Trui dbTrui = repo.GeefTrui(trui.id);
                    if (dbTrui == trui)
                    {
                        throw new TruiManagerException("UpdateTrui - Geen verschillen");
                    } else
                    {
                        repo
                    }
                }
            } catch (Exception ex)
            {

                throw;
            }
        }
        public void GeefTruitjes()
        {

        }
    }
}
