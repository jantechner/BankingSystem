using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Models
{
    public class InterBankPaymentManager
    {
        private static List<OutgoingTransfer> _queuedTransfers = new List<OutgoingTransfer>();
        private static List<Bank> _registeredBanks = new List<Bank>();

        public static void OrderToTransfer(OutgoingTransfer transfer)
        {
            _queuedTransfers.Add(transfer);
        }

        public static void ExecuteTransfers()
        {
            foreach (var transfer in _queuedTransfers)
            {
                ExecuteTransfer(transfer);
            }
        }

        private static void ExecuteTransfer(OutgoingTransfer transfer)
        {
            Account targetAccount = null;
            var targetBank = _registeredBanks.FirstOrDefault(bank =>
                bank.HasAccount(transfer.TargetAccountNumber, out targetAccount));
            if (targetBank == null)
            {
                Console.WriteLine("Cannot make a transfer to given account - target account does not exist");
                transfer.FromAccount.Bank.Execute(new IncreaseBalance(transfer.FromAccount, transfer.Amount));
                transfer.Status = TransferStatus.Rejected;
            }
            else
            {
                targetBank.Execute(new IncomingTransfer(transfer.SenderAccountNumber, targetAccount, transfer.Amount));
                transfer.Status = TransferStatus.Executed;
            }
        }

        public static void RegisterBank(Bank bank)
        {
            _registeredBanks.Add(bank);
        }
    }
}