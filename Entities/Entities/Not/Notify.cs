using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Not
{
    public class Notify
    {
        public Notify()
        {
            Notifications = new List<Notify>();
        }


        [NotMapped]
        public string PropName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notify> Notifications;


        public bool ValidateStringProp(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notifications.Add(new Notify
                {
                    Message = "Campo Obrigatório",
                    PropName = nomePropriedade
                });

                return false;
            }

            return true;
        }


        public bool ValidateIntProp(int valor, string nomePropriedade)
        {

            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notifications.Add(new Notify
                {
                    Message = "Campo Obrigatório",
                    PropName = "nomePropriedade"
                });

                return false;
            }

            return true;

        }
    }
}
