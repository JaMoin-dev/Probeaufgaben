using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ja.training.csharp._05_Umkreissuche
{
    public class TelefonzellenRepository
    {
        private readonly IDbContext context;

        public TelefonzellenRepository(IDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// diese Methode wird vom Webserver aufgerufen, wo der Kunde seine Adresse eingegeben hat.
        /// die Anzahl der zurückgegebenen Telefonzellen kann definiert werden. 
        /// Die Ergebnisliste ist immmer nach Abstand sortiert
        /// </summary>
        /// <param name="searchAddress">z.B. "Heußweg 25, 20255"</param>
        /// <param name="count">Anzahl der zurückzugebeden T-Zellen (z.B. 100)</param>
        public async Task<List<Telefonzelle>> Load(string searchAddress, int count)
        {
            // TODO lädt und sortiert die Telefonzellen von der Datenbank (context)
           
            throw new NotImplementedException();
        }
    }
}
