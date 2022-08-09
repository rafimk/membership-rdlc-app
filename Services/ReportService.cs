using membership_rdlc_app.Dtos;
using Microsoft.Reporting.NETCore;

namespace membership_rdlc_app.Services
{
    public class ReportService : IReportService
    {
        public ReportDto GenerateMembershipCard(MembershipCardDto membershipCard)
        {

            string fileName = "ReceiptV1.rdlc";
            string filePath = "./ReportFiles/";
    
            filePath = Path.Combine(filePath, fileName);
            Console.WriteLine($"File Path is {filePath}");

            using(var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                LocalReport report = new LocalReport();
                report.LoadReportDefinition(fileStream);
                report.SetParameters(new[] 
                { 
                    new ReportParameter("MembershipNo", membershipCard.MembershipNo),
                    new ReportParameter("FullName", membershipCard.FullName),
                    new ReportParameter("State", membershipCard.State),
                    new ReportParameter("District", membershipCard.District),
                    new ReportParameter("Mandalam", membershipCard.Mandalam),
                    new ReportParameter("Panchayath", membershipCard.Panchayath),
                    new ReportParameter("MembershipDate", membershipCard.Date),
                    new ReportParameter("CollectedBy", membershipCard.CollectedBy),
                    new ReportParameter("Area", membershipCard.Area)
                });

                byte[] pdf = report.Render("PDF");
                return new ReportDto
                {
                    File = pdf,
                    FileType = "application/pdf",
                    FileName = $"{membershipCard.MembershipNo}.pdf"
                };
           
            }
        }
    }
}