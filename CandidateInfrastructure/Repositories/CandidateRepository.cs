using CandidateDomain.Repositories;
using CandidateEntites.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateInfrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDbContext _dbContext;

        public CandidateRepository(CandidateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EnsureCreatedAsync()
        {
            return await _dbContext.Database.EnsureCreatedAsync();
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Candidate>().FirstOrDefaultAsync(a => a.Email.Equals(email), cancellationToken);
        }

        public async Task UpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            _dbContext.Set<Candidate>().Update(candidate);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            _dbContext.Set<Candidate>().Add(candidate);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
