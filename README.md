# Jogos em Unity (C#)

Scripts C# de três jogos 2D que fiz no Unity. Foi meu primeiro contato com programação, e o
código está como saiu na época: nomes e comentários informais, sem refatoração.

| Pasta | Jogo | O que os scripts fazem |
|---|---|---|
| [`scripts/morai`](scripts/morai) | Plataforma | Personagem com HUD e tempo de vida, plataformas que caem, paredes mortais, inimigos que perseguem o jogador, menu e troca de fase |
| [`scripts/robColor`](scripts/robColor) | Plataforma com energia | Robô com barra de energia, blocos quebráveis, projéteis, sensores, pausa e menu |
| [`scripts/tueTeste`](scripts/tueTeste) | Tiro 2D | Mira com o mouse, canhão, projéteis, inimigos e pontuação |

Todos usam `Rigidbody2D` para física, `Input` para controle e `SceneManager` para fases e menus.

## Como usar

Este repositório guarda só os scripts, não os projetos Unity completos (cenas, sprites e
sons ficaram de fora). Para testar, copie uma pasta para `Assets/` de um projeto 2D e ligue os
componentes aos objetos da cena.
