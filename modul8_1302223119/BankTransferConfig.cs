using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302223119
{
    class Config
    {
        public string lang {  get; set; }
        public Transfer transfer { get; set; }
        public string[] methods { get; set; }

        public Confirmation confirmation { get; set; }

        public Config(string lang, Transfer transfer, string[] methods, Confirmation confirmation = null)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }

    class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

        public Transfer(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    class Confirmation
    {
        public string en {  get; set; }
        public string id { get; set; }

        public Confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }

    internal class BankTransferConfig
    {
        public Config config;
        private string json;

        public BankTransferConfig(string path)
        {

            try
            {
                config = ReadConfigFile(path);

            } catch (Exception ex)
            {
                SetDefault();
                WriteNewConfigFile(path);
            }
        }
        public Config ReadConfigFile(string path)
        {
            return JsonSerializer.Deserialize<Config>(File.ReadAllText(path));
        }
        public void WriteNewConfigFile(string path)
        {
            JsonSerializerOptions option = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            json = JsonSerializer.Serialize(config, option);
            File.WriteAllText(path, json);
        }
        public void SetDefault()
        {
            config = new Config("en", new Transfer(25000000, 6500, 15000), ["RTO(real - time)", "SKN", "RTGS", "BI FAST"], new Confirmation("yes", "ya"));
        }

    }
}
