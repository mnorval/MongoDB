using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;


namespace MongoDB_Connect
{
    public partial class Main : Form
    {




        public Main()
        {
            InitializeComponent();
        }



        
        private string getresult()
        {

            
            var client = new MongoClient("mongodb://192.168.1.150:27017");
            var database = client.GetDatabase("testdb");
            var collection = database.GetCollection<BsonDocument>("details");
            //textBox1.AppendText("Test" + Environment.NewLine);

            var search_result = (collection.Find(new BsonDocument("Name", "Jack22"))).ToList();
            //var list = await collection.Find(new BsonDocument("Name", "Jack")).ToListAsync();
            string result = search_result[0].ToString();

            /*foreach (var document in list)
            {
                textBox1.AppendText(document["Name"] + Environment.NewLine);
                //Console.WriteLine(document["Name"]);
            }
            */
            return result;
        }

        private void ClickButton2(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://192.168.1.150:27017");
            var database = client.GetDatabase("testdb");
            var collection = database.GetCollection<BsonDocument>("details");

            collection.InsertOne(new BsonDocument("Name", "Jack22"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(getresult());
        }
    }
}
