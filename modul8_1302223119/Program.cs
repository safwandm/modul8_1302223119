// See https://aka.ms/new-console-template for more information
using modul8_1302223119;
using System.Collections;

BankTransferConfig btc = new BankTransferConfig(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\bank_transfer_config.json");

Console.WriteLine(btc.config.lang);

Config cf = btc.config;

if  (btc.config.lang == "en")
{
    Console.WriteLine("Please insert the amount of money to transfer:");
} else if (cf.lang == "id")
{
    Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
}

long money = Convert.ToInt64(Console.ReadLine());

if (money <= cf.transfer.threshold)
{
    money += cf.transfer.low_fee;
    Console.WriteLine($"Transfer fee = {cf.transfer.low_fee} \nTotal amount = {money}");


}
else if (money > cf.transfer.threshold)
{
    money += cf.transfer.high_fee;
    Console.WriteLine($"Transfer fee = {cf.transfer.high_fee} \nTotal amount = {money}");

}

if (cf.lang == "en")
{
    Console.WriteLine("Select transfer method: ");
}  else if (cf.lang == "id")
{
    Console.WriteLine("Pilih metode transfer: ");
}

 int metode = Convert.ToInt32(Console.ReadLine());

int i = 1;
foreach (string method in cf.methods)
{
    Console.WriteLine($"{i} {method}");
    ++i;
}


if (cf.lang == "en")
{
    Console.WriteLine($"Please type \"{cf.confirmation.en}\" to confirm the transaction: ");
}
else if (cf.lang == "id")
{
    Console.WriteLine($"Ketik \"{cf.confirmation.id}\" untuk mengkonfirmasi transaksi:");
}

Console.ReadLine();


if (metode > 4 || metode <= 0)
{
    
}
else
{
    if (cf.lang == "en")
    {
        Console.WriteLine($"The transfer is completed");
    }
    else if (cf.lang == "id")
    {
        Console.WriteLine($"Proses transfer berhasil");
    }
}

