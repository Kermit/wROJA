using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using wROJA.shared;

namespace wROJA.logic
{
    public abstract class AbtractLogic
    {
        protected List<Paragraph> PrepareTimetable(List<TimetableDTO> timetable)
        {
            List<Paragraph> paragraphs = new List<Paragraph>();

            foreach (TimetableDTO obj in timetable)
            {
                Run dayNameRun = new Run("<sup>" + obj.DayName + "</sup>");
                dayNameRun.FontSize = 12;
                dayNameRun.FontWeight = FontWeights.Bold;

                //Dodać ładneijszy wygląd
                Paragraph p = new Paragraph();
                p.Inlines.Add(dayNameRun);
                p.Inlines.Add(Environment.NewLine);
                p.Inlines.Add(new Run(obj.Table));
                p.Inlines.Add(Environment.NewLine);
                p.Inlines.Add(new Run(obj.Legend));
                paragraphs.Add(p);
            }

            return paragraphs;
        }
    }
}
