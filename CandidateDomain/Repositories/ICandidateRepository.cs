using CandidateEntites.Entities;

namespace CandidateDomain.Repositories
{
    public interface ICandidateRepository
    {
        Task<bool> EnsureCreatedAsync();
        Task UpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
        Task CreateCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
        Task<Candidate> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
