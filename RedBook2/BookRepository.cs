using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite;
using System;

namespace RedBook2.Droid
{
    public class BookRepository
    {
        SQLiteConnection database;
        static object locker = new object();
        public BookRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTables<BookUser, BookAdmin, Deleted, OfferRecord, OfferModifications>();
        }

        public IEnumerable<BookUser> GetItems()
        {
            return (from i in database.Table<BookUser>() select i).ToList();
        }

        public IEnumerable<OfferRecord> GetOffers()
        {
            return (from i in database.Table<OfferRecord>() select i).ToList();
        }

        public IEnumerable<OfferModifications> GetModifications()
        {
            return (from i in database.Table<OfferModifications>() select i).ToList();
        }

        public IEnumerable<Deleted> GetDeletedItems()
        {
            return (from i in database.Table<Deleted>() select i).ToList();
        }

        public BookUser GetItem(int id)
        {
            return database.Get<BookUser>(id);
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<BookUser>(id);
            }
        }

        public int DeleteOffer(int id)
        {
            lock (locker)
            {
                return database.Delete<OfferRecord>(id);
            }
        }

        public int DeleteModification(int id)
        {
            lock (locker)
            {
                return database.Delete<OfferModifications>(id);
            }
        }

        public int DeleteDeletedItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Deleted>(id);
            }
        }

        public int DeleteDeleted()
        {
            lock (locker)
            {
                return database.DeleteAll<Deleted>();
            }
        }

        public int DeleteItems()
        {
            lock (locker)
            {
                return database.DeleteAll<BookUser>();
            }
        }

        public int DeleteOffers()
        {
            lock (locker)
            {
                return database.DeleteAll<OfferRecord>();
            }
        }

        public int DeleteModifications()
        {
            lock (locker)
            {
                return database.DeleteAll<OfferModifications>();
            }
        }

        public int SaveItem(BookUser item)
        {
            if (item.BookId != 0)
            {
                database.Update(item);
                return item.BookId;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public int SaveDeleted(Deleted del)
        {
                return database.Insert(del);
        }

        public int SaveOffer(OfferRecord offer)
        {
            return database.Insert(offer);
        }

        public int SaveModification(OfferModifications offerModifications)
        {
            if (offerModifications.ModificationId != 0)
            {
                database.Update(offerModifications);
                return offerModifications.ModificationId;
            }
            else
            {
                return database.Insert(offerModifications);
            }
        }

        public int EditItem(BookUser item)
        {
            database.Update(item);
            return item.BookId;
        }
    }

}