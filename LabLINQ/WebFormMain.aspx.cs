using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LabLINQ.Models;
namespace LabLINQ
{

    public partial class WebFormMain : System.Web.UI.Page
    {
        // Создаем экземпляр класса контекста 
        private toplivoEntities db = new toplivoEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            RunQueries();


        }

        protected void gridLINQVisualize1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridLINQVisualize1.PageIndex = e.NewPageIndex;
        }
        protected void gridLINQVisualize2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridLINQVisualize2.PageIndex = e.NewPageIndex;
        }


        protected void gridLINQVisualize3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridLINQVisualize3.PageIndex = e.NewPageIndex;

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            gridLINQVisualize1.DataBind();
            gridLINQVisualize2.DataBind();
            gridLINQVisualize3.DataBind();


        }
        protected void RunQueries()
        {
            //// Определение LINQ запроса 1
            var queryLINQ1 = from f in db.Operations
                             join t in db.Fuels
                             on f.FuelID equals t.FuelID
                             where (f.Inc_Exp > 0 && f.Date.Value.Year == 2015)
                             orderby f.FuelID descending
                             select new
                             {
                                 Код_операции = f.OperationID,
                                 Назание_топлива = t.FuelType,
                                 Приход_Расход = f.Inc_Exp,
                                 Месяц = f.Date.Value.Month
                             };

            //то же, используя методы расширений
            //var queryLINQ1 = db.Operations.Where(f => (f.Inc_Exp > 0 && f.Date.Value.Year == 2015))
            //.OrderBy(f => f.FuelID)
            //.Join(db.Fuels, f => f.FuelID, t => t.FuelID, (f, t) => new { f.OperationID, t.FuelType, f.Inc_Exp, f.Date.Value.Month });


            //// Визуализация в табличном элементе результатов выполнения запроса 1
            //Выполнение LINQ запроса и передача результатов элементу управления gridLINQVisualize1
            gridLINQVisualize1.Caption = "1. Результат выполнения запроса на выборку отсортированных записей из двух таблиц, удовлетворяющих заданному условию : </b><br><small>" + queryLINQ1.ToString() + "</small><br>";
            gridLINQVisualize1.DataSource = queryLINQ1.ToList();


            //// Определение LINQ запроса 2 
            var queryLINQ2 = from o in db.Operations
                             where (o.Inc_Exp > 0 && o.Date.Value.Year == 2015)
                             group o.Inc_Exp by o.FuelID into gr
                             select new
                             {
                                 Код_топлива = gr.Key,
                                 Количества_топлива = gr.Sum()
                             };
            //то же, используя методы расширений:
            //var queryLINQ2 = db.Operations.Where(o => ((o.Inc_Exp > (Single?)0) && (o.Date.Value.Year == 2015)))
            //    .GroupBy(o => o.FuelID, o => o.Inc_Exp)
            //    .Select(gr => new
            //    {
            //        Код_топлива = gr.Key,
            //        Количества_топлива = gr.Sum()
            //    }
            //     );


            //// Визуализация в табличном элементе результатов выполнения запроса 2
            //Выполнение LINQ запроса и передача результатов элементу управления gridLINQVisualize2
            gridLINQVisualize2.Caption = "2. Результат выполнения запроса на выборку сгруппированных записей из одной таблицы, удовлетворяющих заданному условию, с выполнением групповой операции суммирования : </b><br><small>" + queryLINQ2.ToString() + "</small><br>";

            gridLINQVisualize2.DataSource = queryLINQ2.ToList();


            //// Определение LINQ запроса 3
            var queryLINQ3 = from t in db.Tanks
                             orderby t.TankID descending
                             select new
                             {
                                 Название_Емкости = t.TankType,
                                 Материал_Емкости = t.TankMaterial,
                                 Объем_Емкости = t.TankVolume,
                                 Вес = t.TankWeight
                             };
            //// Визуализация в табличном элементе результатов выполнения запроса 3       

            //Выполнение LINQ запроса и передача результатов элементу управления gridLINQVisualize3
            gridLINQVisualize3.Caption = "3. Результат выполнения запроса на выборку записей из одной таблицы с выводом определенных полей: </b><br><small>" + queryLINQ3.ToString() + "</small><br>";
            gridLINQVisualize3.DataSource = queryLINQ3.ToList();


        }


        protected void ButtonQuery_Click(object sender, EventArgs e)
        {

            RunQueries();

        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            //---------------------
            // Создать новую емкость
            Tanks tank = new Tanks
            {
                TankType = "Бочка",
                TankMaterial = "Дерево",
                TankVolume = 30,
                TankWeight = 100
            };
            //---------------------
            // Создать новый вид топлива
            Fuels fuel = new Fuels
            {
                FuelType = "Нитроглицерин",
                FuelDensity = 3

            };

            // Добавить в DbSet
            db.Tanks.Add(tank);
            db.Fuels.Add(fuel);
            // Сохранить изменения в базе данных
            db.SaveChanges();


            //---------------------
            // Создать новую операцию
            Operations operation = new Operations
            {
                TankID = tank.TankID,
                FuelID = fuel.FuelID,
                Inc_Exp = 100,
                Date = DateTime.Today


            };

            // Добавить в DbSet
            db.Operations.Add(operation);
            // Сохранить изменения в базе данных
            db.SaveChanges();
        }




    }

}