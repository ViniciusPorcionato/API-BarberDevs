namespace webapi.barberdevs.Utils.Mail
{
    public class EmailSedingService
    {
        private readonly IEmailService _emailService;

        public EmailSedingService(IEmailService service)
        {
            _emailService = service;
        }

        public async Task SendWelcomeEmail(string email, string userName)
        {
            try
            {
                MailRequest request = new MailRequest
                {
                    ToEmail = email,
                    Subject = "Bem vindo ao BarberDevs",
                    Body = GetHtmlContent(userName)
                };

                await _emailService.SendEmailAsync(request);
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public async Task SendRocovery(string email, int codigo)
        {
            try
            {
                MailRequest request = new MailRequest
                {
                    ToEmail = email,
                    Subject = "Recuperação de senha",
                    Body = GetHtmlContentRecovery(codigo)
                };

                await _emailService.SendEmailAsync (request);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GetHtmlContent(string userName)
        {
            // Constrói o conteúdo HTML do e-mail, incluindo o nome do usuário
            string Response = @"
    <div style="" width:100%; background-color: #000000; padding: 20px;"">
        <div style="" max-width: 600px; margin: 0 auto; background-color:rgb(87, 13, 13)); border-radius: 10px; padding: 20px;"">
            <img src="" https://barberdevsaccountstorage.blob.core.windows.net/containerbarberdevs/Logologo.png"" alt=""
                Logotipo da Aplicação"" style="" display: block; margin: 0 auto; max-width: 200px;"" />
            <h1 style="""" color: #FFFFFF; text-align: center;"""">Seja Bem-vindo ao BarberDevs !</h1>
            <h3 style="""" color: #FFFFFF; text-align: center;"""">Nosso aplicativo de gerenciamento de cortes </h3>
            <p style="" color: #FFFFFF; text-align: center;"">Olá <strong>" + userName + @"</strong>,</p>
            <p style="""" color: #FFFFFF;text-align: center"""">Aqui, a sua experiência de cuidado pessoal está prestes
                a alcançar um novo patamar de conveniência e estilo.</p>
            <p style="""" color: #FFFFFF;text-align: center"""">Com nossa plataforma intuitiva, você pode agendar seus
                cortes de cabelo com apenas alguns toques na tela do seu dispositivo móvel. </p>
            <p style="""" color: #FFFFFF;text-align: center"""">Explore nosso aplicativo, marque seu próximo horário e
                prepare-se para receber o tratamento VIP que você merece </p>
            <p style="""" color: #FFFFFF;text-align: center"""">Se precisar de suporte técnico para o nosso aplicativo e
                dúvidas, estamos aqui para ajudar. Nossa equipe de suporte especializada está disponível para responder
                às suas perguntas.</p>
            <p style="""" color: #FFFFFF;text-align: center"""">Atenciosamente,<br>Equipe BarberDevs</p>
        </div>
    </div>";

            // Retorna o conteúdo HTML do e-mail
            return Response;
        }

        private string GetHtmlContentRecovery(int codigo)
        {
            string Response = @"
<div style=""width:100%;  background-color: #000000; padding: 20px;"">
    <div style=""max-width: 600px; margin: 0 auto; background-color:rgb(87, 13, 13); border-radius: 10px; padding: 20px;"">
        <img src=""https://barberdevsaccountstorage.blob.core.windows.net/containerbarberdevs/Logologo.png"" alt="" Logotipo da Aplicação"" style="" display: block; margin: 0 auto; max-width: 200px;"" />
        <h1 style=""color: #FFFFFF;text-align: center;"">Recuperação de senha</h1>
        <p style=""color: #FFFFFF;font-size: 24px; text-align: center;"">Código de confirmação <strong>" + codigo + @"</strong></p>
    </div>
</div>";

            return Response;
        }
    }
}
