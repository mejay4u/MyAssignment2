using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyAssignment2.Models;
using MyAssignment2.Models.Entries;
using MyAssignment2.Models.Masters;
using System.Reflection;

namespace MyAssignment2.Controllers.Entries
{
    public class PointofSalesController : Controller
    {
        private ProductContext db = new ProductContext();
       private static DataTable  subsetDt;
        public static bool isSubFlag = false;
        // GET: PointofSales
        public ActionResult Index()
        {
            return View(db.PointofSales.ToList());
        }

        // GET: PointofSales/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointofSales pointofSales = db.PointofSales.Find(id);
            if (pointofSales == null)
            {
                return HttpNotFound();
            }
            return View(pointofSales);
        }

        // GET: PointofSales/Create
        public ActionResult Create()
        {
            PointofSales pos = new PointofSales();

            List<SelectListItem> selectServiceType = new List<SelectListItem>();


            selectServiceType.Add(new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            });
            selectServiceType.Add(new SelectListItem
            {
                Text = "Room Service",
                Value = "1"
            });
            selectServiceType.Add(new SelectListItem
            {
                Text = "Table Service",
                Value = "2"
            });
            selectServiceType.Add(new SelectListItem
            {
                Text = "Parcel Service",
                Value = "3"
            });



            List<SelectListItem> selectRoom = new List<SelectListItem>();
            List<Rooms> roomList = db.Rooms.ToList();
            selectRoom.Add(new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            });
            foreach (var listItem in roomList)
            {

                selectRoom.Add(new SelectListItem
                {
                    Text = listItem.RoomNo,
                    Value = listItem.RoomId.ToString()
                });
            }

            List<SelectListItem> selectTable = new List<SelectListItem>();
            List<Tables> tableList = db.Tables.ToList();
            selectTable.Add(new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            });
            foreach (var listItem in tableList)
            {

                selectTable.Add(new SelectListItem
                {
                    Text = listItem.TableName,
                    Value = listItem.TableId.ToString()
                });
            }
            List<SelectListItem> selectItem = new List<SelectListItem>();
            List<Items> itemList = db.Items.ToList();
            selectItem.Add(new SelectListItem
            {
                Text = "--Select--",
                Value = "0"
            });
            foreach (var listItem in itemList)
            {

                selectItem.Add(new SelectListItem
                {
                    Text = listItem.ItemName,
                    Value = listItem.ItemCode.ToString()
                });
            }
            int intIdt = db.PointofSales.Max(u => (int)u.InvoiceNo);
            pos.CurruntInvoiceNo = (intIdt + 1);

            pos.RoomList = selectRoom;
            pos.TableList = selectTable;
            pos.ItemList = selectItem;
            pos.ServiceTypeList = selectServiceType;

            return View(pos);
        }

        // POST: PointofSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillId,SBId,BillDate,InvoiceNo,ServiceType,RooomId,TableId,ItemCode,TaxAmount,TotoalAmount")] PointofSales pointofSales)
        {
            if (ModelState.IsValid)
            {
                pointofSales.BillId = Guid.NewGuid();
                db.PointofSales.Add(pointofSales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pointofSales);
        }

        // GET: PointofSales/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointofSales pointofSales = db.PointofSales.Find(id);
            if (pointofSales == null)
            {
                return HttpNotFound();
            }
            return View(pointofSales);
        }

        // POST: PointofSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillId,SBId,BillDate,InvoiceNo,ServiceType,RooomId,TableId,ItemCode,TaxAmount,TotoalAmount")] PointofSales pointofSales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pointofSales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pointofSales);
        }

        // GET: PointofSales/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointofSales pointofSales = db.PointofSales.Find(id);
            if (pointofSales == null)
            {
                return HttpNotFound();
            }
            return View(pointofSales);
        }

        // POST: PointofSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PointofSales pointofSales = db.PointofSales.Find(id);
            db.PointofSales.Remove(pointofSales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {

            ProductContext context = new ProductContext();
            int whiteSpaceCount = 0;
            bool noRow = true;
           
            //bool isSubset = false;
            int splitIndex = 0;
            int itemCode;
        




            List<string> searchResults = new List<string>();

            #region Search By Item Code

            if (Int32.TryParse(prefix, out itemCode))
            {

                var subset = (from myRow in context.Items.AsEnumerable()
                              where myRow.ItemCode.ToString().StartsWith(prefix)
                              select myRow);



                List<Items> ItemList = subset.ToList();
                DataTable d = ToDataTable<Items>(ItemList);

                if (subset.Any())
                {
                    isSubFlag = true;

                    subsetDt = new DataTable();
                    subsetDt = d;
                    DataView view = subsetDt.DefaultView;
                    view.Sort = "ItemCode ASC";
                    DataTable sortedDate = view.ToTable();
                    searchResults = getItemNames(sortedDate);
                }
                else
                {
                    searchResults = new List<string>();
                    noRow = false;
                    searchResults.Add("No Results Found");
                }
            }
            else
            {
                for (int i = 0; i < prefix.Length; i++)
                {
                    if (prefix[i].Equals(' '))
                    {
                        whiteSpaceCount++;
                    }
                }

                #endregion Search By Item Code

                #region Search By Item Name
               
                String[] keyWords = prefix.Split(' ');
                foreach (var item in keyWords)
                {
                    if (noRow && item != "")
                    {
                        if (isSubFlag)
                        {
                            if (whiteSpaceCount != 0)
                            {
                                whiteSpaceCount = whiteSpaceCount - 1;
                                splitIndex = splitIndex + 1;
                            }
                            //search the subset dt
                            var subset = (from myRow in subsetDt.AsEnumerable()
                                          where myRow.Field<String>("ItemName").ToLower().Split(' ')[splitIndex].StartsWith(item.ToLower())
                                          select myRow);

                            if (subset.Any())
                            {
                                isSubFlag = true;
                                subsetDt = new DataTable();
                                subsetDt = subset.CopyToDataTable();
                                searchResults = getItemNames(subsetDt);
                            }
                            else
                            {
                                searchResults = new List<string>();
                                noRow = false;
                                isSubFlag = false;
                                searchResults.Add("No Results Found");
                            }
                        }
                        else
                        {
                            var subset = (from myRow in context.Items.AsEnumerable()
                                          where myRow.ItemName.ToLower().StartsWith(item.ToLower())
                                          select myRow);
                            List<Items> ItemList = subset.ToList();
                            DataTable d = ToDataTable<Items>(ItemList);

                            if (subset.Any())
                            {
                                isSubFlag = true;
                                subsetDt = new DataTable();
                                subsetDt = d;
                                searchResults = getItemNames(subsetDt);
                            }
                            else
                            {
                                searchResults = new List<string>();
                                noRow = false;
                                searchResults.Add("No Results Found");
                                isSubFlag = false;
                            }
                        }
                    }
                }

                #endregion Search By Item Name
            }

            return Json(searchResults.ToList());

        }
        private static List<String> getItemNames(DataTable dt)
        {
            List<String> listitem = new List<string>();
            foreach (DataRow item in dt.Rows)
            {
                String itemData = item["ItemCode"].ToString() + "   : " + item["ItemName"].ToString();

                listitem.Add(itemData);
            }
            return listitem;
        }
        //private static List<String> getItemNames(List<Items> list)
        //{
        //    List<string> listitem = new List<string>();
        //    foreach (var item in list)
        //    {
        //        String itemData = item.ItemCode.ToString() + " : " + item.ItemName.ToString();

        //        listitem.Add(itemData);
        //    }
        //    return listitem;
        //}

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
