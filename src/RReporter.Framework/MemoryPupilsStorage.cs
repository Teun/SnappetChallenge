using System.Collections.Generic;
using System.Threading.Tasks;
using RReporter.Application.Domain;
using RReporter.Application.ReportWorkSummary.Depends;

namespace RReporter.Framework
{
    public class MemoryPupilsStorage : IGetPupilsInClass
    {
        public Task<IEnumerable<Pupil>> GetPupilsInClassAsync (int classId)
        {
            switch(classId) {
                case 1:
                    return Task.FromResult((IEnumerable<Pupil>) new[] {
                        new Pupil (40267, "Marthijn Roddenhof"),
                        new Pupil (40268, "Annemiek List"),
                        new Pupil (40270, "Freek Fledderus"),
                        new Pupil (40271, "Gert-Jan Hofmans"),
                        new Pupil (40272, "Jan-Douwe Hengeveld"),
                        new Pupil (40273, "Mareike Grootenboer"),
                        new Pupil (40274, "Jan-Pieter Tasche"),
                        new Pupil (40275, "Albert Garsenaar"),
                        new Pupil (40276, "Mayke de Martijn"),
                        new Pupil (40277, "Margje Lamsma"),
                    });
                case 2: 
                    return Task.FromResult((IEnumerable<Pupil>) new [] {
                        new Pupil (40278, "Rolien Tijhuis over de Brugge"),
                        new Pupil (40279, "Noud Snijders"),
                        new Pupil (40280, "Miesje Reterink"),
                        new Pupil (40281, "Siske van Giessel"),
                        new Pupil (40282, "Maas Ezendam"),
                        new Pupil (40283, "Aaltje van Faassen"),
                        new Pupil (40284, "Leentje ter Morsche"),
                        new Pupil (40285, "Jacoliene Roseboom"),
                        new Pupil (40286, "Ruud Pieffers"),
                        new Pupil (68421, "Gudo ten Tije")
                    });
            }
            return null;
        }
    }
}