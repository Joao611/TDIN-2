using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StoreServiceLib {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StoreService : IStoreService {
        public List<Book> GetBooks() {
            throw new NotImplementedException();
        }

        public int GetBookStock(int bookId) {
            throw new NotImplementedException();
        }

        public void SellBook(int bookId) {
            throw new NotImplementedException();
        }

        public Order SetState(int id) {
            throw new NotImplementedException();
        }
    }
}
