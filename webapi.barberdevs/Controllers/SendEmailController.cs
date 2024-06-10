using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi.barberdevs.Utils.Mail;

namespace webapi.barberdevs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public SendEmailController(IEmailService service)
        {
            emailService = service;
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail(string email, string userName)
        {
            try
            {
                MailRequest mailRequest = new MailRequest();

                mailRequest.ToEmail = email;
                mailRequest.Subject = "Olá, email enviado pelos criadores do BarberDev";
                mailRequest.Body = GetHtmlContent(userName);

                await emailService.SendEmailAsync(mailRequest);

                return Ok("Deu bom");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string? GetHtmlContent(string userName)
        {
            // Constrói o conteúdo HTML do e-mail, incluindo o nome do usuário
            string Response = @"
    <div style="" width:100%; background-color:rgb(87, 13, 13)); padding: 20px;"">
        <div style="" max-width: 600px; margin: 0 auto; background-color:#FFFFFF; border-radius: 10px; padding: 20px;"">
            <img src="" https://barberdevsaccountstorage.blob.core.windows.net/containerbarberdevs/Logologo.png"" alt=""
                Logotipo da Aplicação"" style="" display: block; margin: 0 auto; max-width: 200px;"" />
            <h1 style="""" color: #333333; text-align: center;"""">Seja Bem-vindo ao BarberDevs !</h1>
            <h3 style="""" color: #333333; text-align: center;"""">Nosso aplicativo de gerenciamento de cortes </h3>
            <p style="" color: #666666; text-align: center;"">Olá <strong>" + userName + @"</strong>,</p>
            <p style="""" color: #666666;text-align: center"""">Aqui, a sua experiência de cuidado pessoal está prestes
                a alcançar um novo patamar de conveniência e estilo.</p>
            <p style="""" color: #666666;text-align: center"""">Com nossa plataforma intuitiva, você pode agendar seus
                cortes de cabelo com apenas alguns toques na tela do seu dispositivo móvel. </p>
            <p style="""" color: #666666;text-align: center"""">Explore nosso aplicativo, marque seu próximo horário e
                prepare-se para receber o tratamento VIP que você merece </p>
            <p style="""" color: #666666;text-align: center"""">Se precisar de suporte técnico para o nosso aplicativo e
                dúvidas, estamos aqui para ajudar. Nossa equipe de suporte especializada está disponível para responder
                às suas perguntas.</p>
            <p style="""" color: #666666;text-align: center"""">Atenciosamente,<br>Equipe BarberDevs</p>
        </div>
    </div>";

            // Retorna o conteúdo HTML do e-mail
            return Response;
        }
    }
}
