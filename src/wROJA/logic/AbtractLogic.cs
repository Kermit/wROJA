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
            string legends = string.Empty;

            foreach (TimetableDTO obj in timetable)
            {
                Run dayNameRun = new Run(obj.DayName);                
                dayNameRun.FontWeight = FontWeights.Bold;                

                Paragraph p = new Paragraph();
                p.FontFamily = new System.Windows.Media.FontFamily("Palatino Linotype");
                p.FontSize = 12;
                p.Inlines.Add(dayNameRun);
                p.Inlines.Add(Environment.NewLine);

                foreach (String hour in obj.Table.Split(','))
                {
                    string[] splittedHour = hour.Split(':');                    

                    Run hourRun = new Run(splittedHour[0]);
                    Run minutesRun = new Run(splittedHour[1].Replace(';', ' '));
                    minutesRun.Typography.Variants = FontVariants.Superscript;
                    
                    p.Inlines.Add(hourRun);
                    p.Inlines.Add(minutesRun);
                    p.Inlines.Add(" ");
                }

                legends += obj.Legend;           
                paragraphs.Add(p);
            }

            Paragraph legendParagraph = new Paragraph();
            legendParagraph.FontFamily = new System.Windows.Media.FontFamily("Palatino Linotype");
            legendParagraph.FontSize = 12;
            legendParagraph.Inlines.Add(new Run(legends.Replace(";", Environment.NewLine)));
            paragraphs.Add(legendParagraph);

            return paragraphs;
        }
    }
}
