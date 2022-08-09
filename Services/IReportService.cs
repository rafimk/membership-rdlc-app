using membership_rdlc_app.Dtos;

namespace membership_rdlc_app.Services
{
   public interface IReportService
   {
        ReportDto GenerateMembershipCard(MembershipCardDto membershipCard);
   }
}