using SnappetTrueskill.Domain;

namespace SnappetTrueskill.Data
{
    public interface ITrueskillEventRepository
    {
        void Add(TrueskillEvent trueskillEvent);
        void Save();
    }
}