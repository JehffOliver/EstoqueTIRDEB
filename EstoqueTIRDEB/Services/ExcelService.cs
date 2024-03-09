using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EstoqueTIRDEB.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace EstoqueTIRDEB.Services
{
    public class ExcelService
    {
        public async Task<IEnumerable<Itens>> ReadCsvAsync(Stream stream)
        {
            List<Itens> items = new List<Itens>();

            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;

                // Desabilita os eventos HeaderValidated e MissingFieldFound
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;

                await csv.ReadAsync(); // Move para a próxima linha (cabeçalho)
                csv.ReadHeader(); // Lê o cabeçalho do CSV

                while (await csv.ReadAsync())
                {
                    var item = new Itens
                    {
                        CD = csv.GetField<string>(0),
                        Fabricante = csv.GetField<string>(1),
                        Equipamento = csv.GetField<string>(2),
                        Modelo = csv.GetField<string>(3),
                        NotaFiscal = csv.GetField<string>(4),
                        Patrimonio = csv.GetField<string>(5),
                        SistemaOperacional = csv.GetField<string>(6),
                        DepartamentoSetor = csv.GetField<string>(7),
                        Hostname = csv.GetField<string>(8),
                        DataAquisicao = csv.GetField<DateTime>(9) // Supondo que a data está na última coluna
                    };

                    items.Add(item);
                }
            }

            return items;
        }
    }
}