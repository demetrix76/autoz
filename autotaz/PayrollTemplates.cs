using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autotaz
{
    internal static class PayrollTemplates
    {
        public readonly static string HeaderTemplate = @"
<!DOCTYPE html>
<html>
    <head>
        <style type=""text/css"">
            body {{ font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; }}
            h2 {{ text-align: center;}}
            table {{ border-collapse: collapse; margin-bottom: 1em; }}
            td {{border: 1pt solid black; padding: 0pt 4pt;}}
            th {{border: 1pt solid black; padding: 0pt 4pt; border-bottom: 4pt solid black;}}
        </style>
    </head>
    <body>
        <h1>ПАО ""Автозавод""</h1>
        <h2>Расчётный лист сотрудника</h2>
        <table>
            <tr>
                <td>ФИО</td>
                <td>{0}</td>
            </tr>
            <tr>
                <td>Расчётный период</td>
                <td>{1}</td>
            </tr>
            <tr>
                <td>Рабочих дней в периоде</td>
                <td>{2}</td>
            </tr>
            <tr>
                <td>Рабочих часов в периоде</td>
                <td>{3}</td>
            </tr>
        </table>

        <table style=""width:100%"">
            <tr>
                <th>Н.пп</th>
                <th>Период</th>
                <th>Подразделение</th>
                <th>З/п в месяц</th>
                <th>Часовая ставка</th>
                <th>Отработано часов</th>
                <th>Начислено за период</th>
            </tr>
";

        public readonly static string WorkRowTemplate = @"
            <tr>
                <td align=""center"">{0}</td>
                <td>{1}</td>
                <td>{2}</td>
                <td align=""right"">{3:# ##0.00}</td>
                <td align=""right"">{4:# ##0.00}</td>
                <td align=""right"">{5}</td>
                <td align=""right"">{6:# ##0.00}</td>
            </tr>
";

        public readonly static string TotalRowTemplate = @"
            <tr style=""border-top:4pt solid black"">
                <td colspan=""5"">Итого</td>
                <td align=""right"">{0}</td>
                <td align=""right"">{1:# ##0.00}</td>
            </tr>
        </table>
";

        public readonly static string FooterTemplate = @"
    </body>
</html>
";

    }
}
