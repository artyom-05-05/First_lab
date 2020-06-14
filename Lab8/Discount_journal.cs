using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab8
{
    class Discount_journal
    {
        private string discountJournalName;
        private List<Discount> journal = new List<Discount>();

        public Discount_journal(String journalName)
        {
            discountJournalName = journalName;
        }

        public bool AddNewDiscount(string shop, int sizeOfDiscount, DateTime expirationDate)
        {
            if (journal.Any(o => o.GetShop() == shop)) return false;

            journal.Add(new Discount(shop, sizeOfDiscount, expirationDate));
            return true;
        }

        public bool DeleteDiscount(string shop)
        {
            if (!journal.Any(o => o.GetShop() == shop)) return false;

            journal.Remove(journal.Find(o => o.GetShop() == shop));
            return true;
        }

        public List<Discount> GetSortList()
        {
            List<Discount> sortList = journal.OrderBy(d => d.GetShop()).ToList();
            return sortList;
        }
    }

    class Discount
    {
        private readonly string shop;
        private readonly int sizeOfDiscount;
        private readonly DateTime expirationDate;

        public Discount(string shop, int sizeOfDiscount, DateTime expirationDate)
        {
            this.shop = shop;
            this.sizeOfDiscount = sizeOfDiscount;
            this.expirationDate = expirationDate;
        }

        public string GetShop() { return this.shop; }

        public int GetSizeOfDiscount() { return this.sizeOfDiscount; }

        public DateTime GetExpirationDate() { return this.expirationDate; }
    }

}
