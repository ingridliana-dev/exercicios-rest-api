using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exercicios_rest_api.Controllers {
    [Route("api/atv")] // Endereço da API
    [ApiController]
    public class atvController : ControllerBase {

        [Route("onePiece")]
        [HttpGet]
        public IActionResult OnePiece() {
            string mensagem = "One Piece is Real! RESTFULAPI";

            return Ok(mensagem);
        }

        [Route("onePieceNome")]
        [HttpGet]
        public string OnePieceNome(string nome) {
            string mensagem = "One Piece is real " + nome;

            return mensagem;
        }

        [Route("soma")]
        [HttpGet]
        public string Soma(float n1, float n2) {
            float soma = n1 + n2;
            string mensagem = "A soma é " + soma;
            return mensagem;
        }

        [Route("media")]
        [HttpGet]
        public string Media(float n1, float n2) {
            float media = (n1 + n2) / 2;
            string mensagem = "A média é " + media;
            return mensagem;
        }

        [Route("terreno")]
        [HttpGet]
        public string Terreno(float larg, float comp, float preco) {
            float area = larg * comp;
            float precoTotal = area * preco;

            string mensagem = $"A área total: {area:N} " +
                              $"\nValor total: R$ {precoTotal:N}.";
            return mensagem;
        }

        [Route("troco")]
        [HttpGet]
        public string Troco(float preco, int qtd, float dinheiro) {
            float totalCompra = preco * qtd;
            float troco = dinheiro - totalCompra;

            string mensagem = $"Valor da Compra: R$ {totalCompra:N} " +
                              $"\nTroco: R$ {troco:N}";
            if(troco < 0) {
                troco *= -1;
                mensagem = $"R$ {dinheiro} não foi o suficiente.\n"+
                           $"Ainda falta R$ {troco}";
            }

            return mensagem;
        }

        [Route("salario")]
        [HttpGet]
        public string Salario(string nome, float valorHora, float qtdHoras) {

            float salario = valorHora * qtdHoras;

            string mensagem = $"Nome: {nome} " +
                              $"\nValor por Hora: R$ {valorHora} " +
                              $"\nHoras Trabalhada: {qtdHoras} horas" +
                              $"\nSalário: R$ {salario:N}";

            return mensagem;
        }

        [Route("consumo")]
        [HttpGet]
        public string Consumo(float km, float litros) {

            float cons = km / litros;

            string mensagem = $"Rendimento: {cons} km por litro ";

            return mensagem;
        }

    }
}
