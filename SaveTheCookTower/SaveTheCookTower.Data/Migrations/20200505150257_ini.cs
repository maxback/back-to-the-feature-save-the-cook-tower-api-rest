using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaveTheCookTower.Data.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_categoria_pai = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_categoria_categoria_id_categoria_pai",
                        column: x => x.id_categoria_pai,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fonte_prop_intelec",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    s_autor = table.Column<string>(nullable: true),
                    s_titulo = table.Column<string>(nullable: true),
                    n_pagina_livro = table.Column<int>(nullable: true),
                    s_edicao_livro = table.Column<string>(nullable: true),
                    uri_origem = table.Column<string>(nullable: true),
                    dt_acesso = table.Column<DateTime>(nullable: false),
                    m_comentario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fonte_prop_intelec", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unidade_medida",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    n_tipo = table.Column<int>(nullable: false),
                    _nome_resumido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidade_medida", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    s_email = table.Column<string>(nullable: true),
                    s_login = table.Column<string>(nullable: true),
                    s_password = table.Column<string>(nullable: true),
                    s_token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cardapio",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_cardapio = table.Column<Guid>(nullable: false),
                    m_descricao = table.Column<string>(nullable: true),
                    m_imagens_url = table.Column<string>(nullable: true),
                    m_videos_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardapio", x => x.id);
                    table.ForeignKey(
                        name: "FK_cardapio_categoria_id_cardapio",
                        column: x => x.id_cardapio,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingrediente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_categoria = table.Column<Guid>(nullable: false),
                    m_imagens_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingrediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_ingrediente_categoria_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receita",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_receita_pai = table.Column<Guid>(nullable: true),
                    id_categoria = table.Column<Guid>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    n_tempo_preparo_minutos = table.Column<int>(nullable: true),
                    n_redimento_porcoes = table.Column<int>(nullable: true),
                    id_fonte = table.Column<Guid>(nullable: true),
                    id_avaliacao_media = table.Column<Guid>(nullable: true),
                    m_imagens_url = table.Column<string>(nullable: true),
                    m_videos_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receita", x => x.id);
                    table.ForeignKey(
                        name: "FK_receita_categoria_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receita_fonte_prop_intelec_id_fonte",
                        column: x => x.id_fonte,
                        principalTable: "fonte_prop_intelec",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_receita_receita_id_receita_pai",
                        column: x => x.id_receita_pai,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "unidade_medida_equiv",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_unidade_orig = table.Column<Guid>(nullable: true),
                    id_unidade_dest = table.Column<Guid>(nullable: true),
                    nu_razao_orig_dest = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidade_medida_equiv", x => x.id);
                    table.ForeignKey(
                        name: "FK_unidade_medida_equiv_unidade_medida_id_unidade_dest",
                        column: x => x.id_unidade_dest,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_unidade_medida_equiv_unidade_medida_id_unidade_orig",
                        column: x => x.id_unidade_orig,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item_cardapio",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    CardapioId = table.Column<Guid>(nullable: false),
                    n_semana = table.Column<int>(nullable: false),
                    n_dia_da_semana = table.Column<int>(nullable: false),
                    n_porcoes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_cardapio", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_cardapio_cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "cardapio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avaliacao_usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    qtd_estrelas = table.Column<int>(nullable: true),
                    id_usuario = table.Column<Guid>(nullable: false),
                    id_receita = table.Column<Guid>(nullable: true),
                    id_receita_media = table.Column<Guid>(nullable: true),
                    b_eh_aval_media = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacao_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_avaliacao_usuario_receita_id_receita_media",
                        column: x => x.id_receita_media,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_avaliacao_usuario_receita_id_receita",
                        column: x => x.id_receita,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_avaliacao_usuario_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etapa_preparo",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    id_receita = table.Column<Guid>(nullable: false),
                    n_ordem = table.Column<int>(nullable: false),
                    m_descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etapa_preparo", x => x.id);
                    table.ForeignKey(
                        name: "FK_etapa_preparo_receita_id_receita",
                        column: x => x.id_receita,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "info_nutricional",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    n_quantidade = table.Column<double>(nullable: false),
                    id_unidade_medida = table.Column<Guid>(nullable: false),
                    id_ingrediente = table.Column<Guid>(nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_nutricional", x => x.id);
                    table.ForeignKey(
                        name: "FK_info_nutricional_ingrediente_id_ingrediente",
                        column: x => x.id_ingrediente,
                        principalTable: "ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_info_nutricional_receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_info_nutricional_unidade_medida_id_unidade_medida",
                        column: x => x.id_unidade_medida,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_lista_ingrediente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    n_ordem = table.Column<int>(nullable: false),
                    n_quantidade = table.Column<double>(nullable: false),
                    id_unidade_medida = table.Column<Guid>(nullable: false),
                    id_ingrediente = table.Column<Guid>(nullable: false),
                    id_receia = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_lista_ingrediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_lista_ingrediente_ingrediente_id_ingrediente",
                        column: x => x.id_ingrediente,
                        principalTable: "ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_lista_ingrediente_receita_id_receia",
                        column: x => x.id_receia,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_item_lista_ingrediente_unidade_medida_id_unidade_medida",
                        column: x => x.id_unidade_medida,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_cardapio_receita",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    dt_criacao = table.Column<DateTime>(nullable: false),
                    id_usu_criacao = table.Column<Guid>(nullable: true),
                    dt_atualizacao = table.Column<DateTime>(nullable: false),
                    id_Usu_atualizacao = table.Column<Guid>(nullable: true),
                    b_fora_uso = table.Column<bool>(nullable: false),
                    s_nome = table.Column<string>(nullable: false),
                    m_sinonimos = table.Column<string>(nullable: true),
                    s_uri = table.Column<string>(nullable: true),
                    ItemCardapioId = table.Column<Guid>(nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_cardapio_receita", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_cardapio_receita_item_cardapio_ItemCardapioId",
                        column: x => x.ItemCardapioId,
                        principalTable: "item_cardapio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_item_cardapio_receita_receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[] { new Guid("44c85429-abfe-44d4-9e4a-3dde505d8515"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(2696), null, null, new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(2688), null, false, null, "Categorias", "Categoria Raiz" });

            migrationBuilder.InsertData(
                table: "unidade_medida",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "_nome_resumido", "m_sinonimos", "n_tipo" },
                values: new object[,]
                {
                    { new Guid("6fa17f5c-dafe-4356-9f36-41b9d36c5990"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(2131), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(2122), null, false, null, "unidade", "un", "unidades,unidade(un)", 2 },
                    { new Guid("e54e8d0f-8f28-4323-a461-7d3fbed89db3"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5353), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5345), null, false, null, "grama", "g", "gramas,grama(g)", 3 },
                    { new Guid("e371b255-a9ed-4983-9df9-c2bbe17ab88e"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5463), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5460), null, false, null, "kilograma", "kg", "kilo,kilos,kilo gramas,kilogramas,kilograma(kg)", 3 },
                    { new Guid("9c9fb002-47ec-4322-92b9-c035fa8d69dd"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5476), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5474), null, false, null, "litro", "l", "litros,litro(l)", 4 },
                    { new Guid("3231aeff-289a-4b95-a354-d8fe019e6366"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5579), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5576), null, false, null, "xícara de chá", "xíc", "xic,cicara de cha, xícara chá, xícaras de chá,xícara(chá)", 4 },
                    { new Guid("adcd900e-5317-45e6-a01b-3b15b560ecc8"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5647), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5644), null, false, null, "pitada", "pt", "pitada,punhadinho,cadinho", 4 },
                    { new Guid("33a797f5-3c1d-4782-9984-a674a4c638dc"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5750), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5748), null, false, null, "colher de sopa", "cso", "colher media", 4 },
                    { new Guid("9b82d705-1e78-4c8d-a639-b53096e70a31"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5804), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5802), null, false, null, "fatia", "fat", "fatia", 4 },
                    { new Guid("08d88fcf-ea35-4b33-a870-599f0ce8cf32"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5857), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5855), null, false, null, "unidade", "un", "unidade", 2 },
                    { new Guid("fc6dca5d-94c7-4a59-85e8-5739e7efa0fb"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5701), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5699), null, false, null, "colher de chá", "ccha", "colher pequena", 4 },
                    { new Guid("937cb99e-d87f-40df-9009-3b5abecf2d84"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5917), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5915), null, false, null, "metro", "m", "metros,metro(m)", 1 },
                    { new Guid("78be9b06-a0e1-47c5-8f40-5c13061eb1f2"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5990), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(5987), null, false, null, "milimetro", "mm", "milimetros,milimetro(ml)", 1 }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "s_email", "b_fora_uso", "s_uri", "s_login", "s_nome", "s_password", "m_sinonimos", "s_token" },
                values: new object[,]
                {
                    { new Guid("90aab973-14aa-48bd-bc54-441f18d29cdb"), new DateTime(2020, 5, 5, 15, 2, 55, 773, DateTimeKind.Utc).AddTicks(6209), null, new DateTime(2020, 5, 5, 15, 2, 55, 773, DateTimeKind.Utc).AddTicks(4969), null, "adm@adm.com", false, null, "adm", "Administrador do sistema", "202cb962ac59075b964b07152d234b70", null, null },
                    { new Guid("c3ba4922-4c86-4bae-be4b-0f036389b0cf"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(280), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(242), null, "teste@teste.com", false, null, "string", "Usuário de testes com login string e senha string", "b45cffe084dd3d20d928bee85e7b0f21", null, null }
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("ad93c813-de74-4bf8-9383-d405a8ada49c"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(3928), null, new Guid("44c85429-abfe-44d4-9e4a-3dde505d8515"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(3920), null, false, null, "Ingredientes", "Categoria Raiz dos Ingredientes" },
                    { new Guid("10faa48a-deae-4967-8399-b20f413f0e54"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5107), null, new Guid("44c85429-abfe-44d4-9e4a-3dde505d8515"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5100), null, false, null, "Cardápios", "Categoria Raiz dos Cardápios" },
                    { new Guid("d25189af-510c-43b8-b225-89a7c8518067"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5212), null, new Guid("44c85429-abfe-44d4-9e4a-3dde505d8515"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5209), null, false, null, "Receitas", "Categoria Raiz das Receitas" }
                });

            migrationBuilder.InsertData(
                table: "unidade_medida_equiv",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "id_unidade_dest", "b_fora_uso", "s_uri", "s_nome", "id_unidade_orig", "nu_razao_orig_dest", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("b9824e28-8622-4e17-9ec1-f7f379254d1a"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(1628), null, new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(1620), null, new Guid("9c9fb002-47ec-4322-92b9-c035fa8d69dd"), false, null, "xícaras de chá pra litros", new Guid("3231aeff-289a-4b95-a354-d8fe019e6366"), 0.25, "razão xíc/l, xícara de chá apra litros,xíc para l,xic para l" },
                    { new Guid("502e2046-a681-47be-8cc9-34ab9c796b52"), new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(7087), null, new DateTime(2020, 5, 5, 15, 2, 55, 783, DateTimeKind.Utc).AddTicks(7079), null, new Guid("78be9b06-a0e1-47c5-8f40-5c13061eb1f2"), false, null, "metro para milimetros", new Guid("937cb99e-d87f-40df-9009-3b5abecf2d84"), 0.001, "razão m/ml, metro para milimetros,m para ml" }
                });

            migrationBuilder.InsertData(
                table: "cardapio",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_cardapio", "dt_criacao", "id_usu_criacao", "m_descricao", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "m_sinonimos", "m_videos_url" },
                values: new object[] { new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 786, DateTimeKind.Utc).AddTicks(190), null, new Guid("10faa48a-deae-4967-8399-b20f413f0e54"), new DateTime(2020, 5, 5, 15, 2, 55, 786, DateTimeKind.Utc).AddTicks(182), null, "Dieta abase de pão comum", false, null, null, "Comendo pão no café da manhã todo dia (mensal)", "café", null });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("26267275-8c0a-4d91-b7eb-2587249b85dd"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5311), null, new Guid("d25189af-510c-43b8-b225-89a7c8518067"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5308), null, false, null, "Tortas", "Categoria Raiz das tortas" },
                    { new Guid("62074504-b97e-4b2d-bdf0-bb40265024e5"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5331), null, new Guid("d25189af-510c-43b8-b225-89a7c8518067"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5330), null, false, null, "Café da manhã", "Cafe da manha" },
                    { new Guid("fc4e215b-6dfc-4db0-8c9b-e4a35e6e750d"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5455), null, new Guid("d25189af-510c-43b8-b225-89a7c8518067"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(5452), null, false, null, "Jantar", "Categoria Raiz dos Jantares" }
                });

            migrationBuilder.InsertData(
                table: "ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria", "dt_criacao", "id_usu_criacao", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("8061d894-dc40-4315-a1bd-f32eb6a13fc0"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(6342), null, new Guid("ad93c813-de74-4bf8-9383-d405a8ada49c"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(6334), null, false, null, null, "Farinha de Trigo", "Trigo" },
                    { new Guid("c24449e8-03f4-423d-a0b4-bffc207021c0"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(7621), null, new Guid("ad93c813-de74-4bf8-9383-d405a8ada49c"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(7614), null, false, null, null, "Fermento para Pão", "Fermento biológico" },
                    { new Guid("fff275f4-152f-43e0-bd2c-f3a86be650fc"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(7725), null, new Guid("ad93c813-de74-4bf8-9383-d405a8ada49c"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(7722), null, false, null, null, "Ovo de galinha", "Ovo" },
                    { new Guid("42a1cdca-3015-44f3-a1ea-ca6b832b3e38"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(7784), null, new Guid("ad93c813-de74-4bf8-9383-d405a8ada49c"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(7781), null, false, null, null, "Água", "Agua" }
                });

            migrationBuilder.InsertData(
                table: "item_cardapio",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "CardapioId", "dt_criacao", "id_usu_criacao", "n_dia_da_semana", "b_fora_uso", "s_uri", "s_nome", "n_porcoes", "n_semana", "m_sinonimos", "Tipo" },
                values: new object[,]
                {
                    { new Guid("e3f3f47d-7524-428e-b32b-aadd9341fae1"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(1787), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(1752), null, 1, false, null, "Domingo da semana $1 - $Café da Manhã", 1, 1, null, 1 },
                    { new Guid("25bc0d10-727b-4df9-b666-bb90a92e1cd6"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2611), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2607), null, 6, false, null, "Sexta-feira da semana $4 - $Café da Manhã", 1, 4, null, 1 },
                    { new Guid("aa221fac-a392-4472-8675-f4226e6246cc"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2412), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2408), null, 5, false, null, "Quinta-feira da semana $4 - $Café da Manhã", 1, 4, null, 1 },
                    { new Guid("7cba3a13-a805-45b3-bc4b-59dc8751875a"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2214), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2210), null, 4, false, null, "Quarta-feira da semana $4 - $Café da Manhã", 1, 4, null, 1 },
                    { new Guid("4edfcbec-b451-4041-9c61-c4dd1169c55e"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2016), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2012), null, 3, false, null, "Terça-feira da semana $4 - $Café da Manhã", 1, 4, null, 1 },
                    { new Guid("da1e1e03-e976-4c08-9819-99ceaded51ce"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(1817), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(1813), null, 2, false, null, "Segunda-feira da semana $4 - $Café da Manhã", 1, 4, null, 1 },
                    { new Guid("23c676bb-86d2-4317-bb8b-d918d4332bf5"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(1615), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(1611), null, 1, false, null, "Domingo da semana $4 - $Café da Manhã", 1, 4, null, 1 },
                    { new Guid("cce88608-963e-4c0d-a20f-07ef5284be64"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(1405), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(1400), null, 7, false, null, "Sábado da semana $3 - $Café da Manhã", 1, 3, null, 1 },
                    { new Guid("33f51fd4-3ec9-4ee7-ab44-178f98d2160f"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(1169), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(1165), null, 6, false, null, "Sexta-feira da semana $3 - $Café da Manhã", 1, 3, null, 1 },
                    { new Guid("521ac6fc-9722-4a25-9b7b-ad966c7ee95a"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(921), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(917), null, 5, false, null, "Quinta-feira da semana $3 - $Café da Manhã", 1, 3, null, 1 },
                    { new Guid("0f6e9bfc-99ea-48c7-992e-ea648cd6df7e"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(722), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(718), null, 4, false, null, "Quarta-feira da semana $3 - $Café da Manhã", 1, 3, null, 1 },
                    { new Guid("c3cf167d-1429-4c53-905b-0595a1a400a0"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(515), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(511), null, 3, false, null, "Terça-feira da semana $3 - $Café da Manhã", 1, 3, null, 1 },
                    { new Guid("3288c56c-29c3-471f-bbbc-5c6b32819ff8"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(316), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(312), null, 2, false, null, "Segunda-feira da semana $3 - $Café da Manhã", 1, 3, null, 1 },
                    { new Guid("414b8c6a-524d-45e4-ae70-0da38d67b8b1"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2809), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(2805), null, 7, false, null, "Sábado da semana $4 - $Café da Manhã", 1, 4, null, 1 },
                    { new Guid("294a030d-e302-4d0c-a691-b90ef54dbc9a"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(114), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(110), null, 1, false, null, "Domingo da semana $3 - $Café da Manhã", 1, 3, null, 1 },
                    { new Guid("fbabbce7-42a4-49c5-a939-30b5b4f50ea9"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9706), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9701), null, 6, false, null, "Sexta-feira da semana $2 - $Café da Manhã", 1, 2, null, 1 },
                    { new Guid("cdeca2b5-0fb5-4c8c-8b39-e6f2d86abf73"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9480), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9476), null, 5, false, null, "Quinta-feira da semana $2 - $Café da Manhã", 1, 2, null, 1 },
                    { new Guid("f2378410-219e-4c7a-ac03-8fa6522139da"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9268), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9264), null, 4, false, null, "Quarta-feira da semana $2 - $Café da Manhã", 1, 2, null, 1 },
                    { new Guid("45c7a224-7153-40f0-aaa0-e50e9204351c"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9067), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9063), null, 3, false, null, "Terça-feira da semana $2 - $Café da Manhã", 1, 2, null, 1 },
                    { new Guid("2c2fe350-9c5d-4f0a-8d53-8ac4bf7f32f6"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8856), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8852), null, 2, false, null, "Segunda-feira da semana $2 - $Café da Manhã", 1, 2, null, 1 },
                    { new Guid("10343b07-8b1c-46f0-9a7b-4a61f45fa006"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8654), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8650), null, 1, false, null, "Domingo da semana $2 - $Café da Manhã", 1, 2, null, 1 },
                    { new Guid("7c3afe4d-2907-4ccb-8ed2-ff6443ed22af"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8451), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8446), null, 7, false, null, "Sábado da semana $1 - $Café da Manhã", 1, 1, null, 1 },
                    { new Guid("e40af40f-4b1b-4576-bbac-25211ec68a39"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8247), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8243), null, 6, false, null, "Sexta-feira da semana $1 - $Café da Manhã", 1, 1, null, 1 },
                    { new Guid("d915e019-c1db-47b6-a0c9-4d3fd39daab2"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8025), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(8020), null, 5, false, null, "Quinta-feira da semana $1 - $Café da Manhã", 1, 1, null, 1 },
                    { new Guid("ca4a6ab6-e4af-49bc-b539-068295555ec3"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(7778), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(7774), null, 4, false, null, "Quarta-feira da semana $1 - $Café da Manhã", 1, 1, null, 1 },
                    { new Guid("e268dc25-b04e-4fb4-b11c-ad5ebab15f3c"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(7534), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(7528), null, 3, false, null, "Terça-feira da semana $1 - $Café da Manhã", 1, 1, null, 1 },
                    { new Guid("6197df82-2aa3-4d36-8fda-6d5362f01790"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(7163), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(7154), null, 2, false, null, "Segunda-feira da semana $1 - $Café da Manhã", 1, 1, null, 1 },
                    { new Guid("099683cc-5bc3-4c15-b407-1cb6de6c604d"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9913), null, new Guid("65069fcf-c2d3-4dba-8abe-fb8664d77dc4"), new DateTime(2020, 5, 5, 15, 2, 55, 787, DateTimeKind.Utc).AddTicks(9908), null, 7, false, null, "Sábado da semana $2 - $Café da Manhã", 1, 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "receita",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_avaliacao_media", "id_categoria", "dt_criacao", "id_usu_criacao", "descricao", "id_fonte", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "id_receita_pai", "n_redimento_porcoes", "m_sinonimos", "n_tempo_preparo_minutos", "m_videos_url" },
                values: new object[] { new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(8723), null, null, new Guid("62074504-b97e-4b2d-bdf0-bb40265024e5"), new DateTime(2020, 5, 5, 15, 2, 55, 784, DateTimeKind.Utc).AddTicks(8715), null, null, null, false, null, null, "Pão de Forma", null, 5, "Pão assado,pao assado", 120, null });

            migrationBuilder.InsertData(
                table: "item_cardapio_receita",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "ItemCardapioId", "s_uri", "s_nome", "ReceitaId", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("aef2f02d-77c9-4013-93c2-642cb6068842"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(3938), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(3930), null, false, new Guid("e3f3f47d-7524-428e-b32b-aadd9341fae1"), null, "Rel. Item Cardápio(Domingo da semana $1 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("fb75ef4d-9b75-43bb-81d1-712cb5e57e24"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7982), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7979), null, false, new Guid("414b8c6a-524d-45e4-ae70-0da38d67b8b1"), null, "Rel. Item Cardápio(Sábado da semana $4 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("c8dbd15a-dc51-4113-b865-b5e7fea71dba"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7922), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7919), null, false, new Guid("25bc0d10-727b-4df9-b666-bb90a92e1cd6"), null, "Rel. Item Cardápio(Sexta-feira da semana $4 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("9b9b1dc8-9e1b-4464-b045-31f6b9d067f6"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7860), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7858), null, false, new Guid("aa221fac-a392-4472-8675-f4226e6246cc"), null, "Rel. Item Cardápio(Quinta-feira da semana $4 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("d08b268e-fe40-410f-b620-ce25a75a7df2"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7794), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7791), null, false, new Guid("7cba3a13-a805-45b3-bc4b-59dc8751875a"), null, "Rel. Item Cardápio(Quarta-feira da semana $4 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("58e6dafb-fbdb-4477-9052-df877b7373d8"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7714), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7712), null, false, new Guid("4edfcbec-b451-4041-9c61-c4dd1169c55e"), null, "Rel. Item Cardápio(Terça-feira da semana $4 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("8d70b5fb-f02d-4449-b4e5-58da7ac383d8"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7650), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7648), null, false, new Guid("da1e1e03-e976-4c08-9819-99ceaded51ce"), null, "Rel. Item Cardápio(Segunda-feira da semana $4 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("8995f09c-9681-4dcd-baee-bc8b1d9229aa"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7582), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7580), null, false, new Guid("23c676bb-86d2-4317-bb8b-d918d4332bf5"), null, "Rel. Item Cardápio(Domingo da semana $4 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("8ef5b64c-7d0c-43fc-8e74-a83a1f017060"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7522), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7519), null, false, new Guid("cce88608-963e-4c0d-a20f-07ef5284be64"), null, "Rel. Item Cardápio(Sábado da semana $3 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("54cce02d-bde6-4dcf-9c2e-82072cfe88cb"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7460), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7457), null, false, new Guid("33f51fd4-3ec9-4ee7-ab44-178f98d2160f"), null, "Rel. Item Cardápio(Sexta-feira da semana $3 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("204ec46d-ee62-4ec8-836d-4bce6dac26c3"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7399), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7397), null, false, new Guid("521ac6fc-9722-4a25-9b7b-ad966c7ee95a"), null, "Rel. Item Cardápio(Quinta-feira da semana $3 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("ae81e26d-074d-4f2f-b2b2-438a773fb85d"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7338), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7335), null, false, new Guid("0f6e9bfc-99ea-48c7-992e-ea648cd6df7e"), null, "Rel. Item Cardápio(Quarta-feira da semana $3 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("3c113b7f-33c0-4624-9ad2-e5182e0ce101"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7189), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7187), null, false, new Guid("3288c56c-29c3-471f-bbbc-5c6b32819ff8"), null, "Rel. Item Cardápio(Segunda-feira da semana $3 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("0370a7dc-a902-468b-a19a-f18f46298b8c"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7129), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7126), null, false, new Guid("294a030d-e302-4d0c-a691-b90ef54dbc9a"), null, "Rel. Item Cardápio(Domingo da semana $3 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("d1a6291a-02f4-4e2f-abea-2ab4fa1e72cb"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7269), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7266), null, false, new Guid("c3cf167d-1429-4c53-905b-0595a1a400a0"), null, "Rel. Item Cardápio(Terça-feira da semana $3 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("ce93177a-f175-4b1e-81e4-114cb9d6be1c"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7007), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7004), null, false, new Guid("fbabbce7-42a4-49c5-a939-30b5b4f50ea9"), null, "Rel. Item Cardápio(Sexta-feira da semana $2 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("cad1e79c-74a7-437d-8ba3-7b3bfa0e186c"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6219), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6210), null, false, new Guid("6197df82-2aa3-4d36-8fda-6d5362f01790"), null, "Rel. Item Cardápio(Segunda-feira da semana $1 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("7b36a671-0b4c-469a-a440-709dc07ae1b5"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6330), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6327), null, false, new Guid("e268dc25-b04e-4fb4-b11c-ad5ebab15f3c"), null, "Rel. Item Cardápio(Terça-feira da semana $1 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("a7a0683f-5a4e-472d-86e9-a8fd4c630b6f"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6394), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6392), null, false, new Guid("ca4a6ab6-e4af-49bc-b539-068295555ec3"), null, "Rel. Item Cardápio(Quarta-feira da semana $1 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("13b0b013-e8d7-4eae-862c-42ab67a7e540"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6458), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6455), null, false, new Guid("d915e019-c1db-47b6-a0c9-4d3fd39daab2"), null, "Rel. Item Cardápio(Quinta-feira da semana $1 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("e7771457-e3d8-45e1-9ea6-efa7ff8aa6c1"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7068), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(7066), null, false, new Guid("099683cc-5bc3-4c15-b407-1cb6de6c604d"), null, "Rel. Item Cardápio(Sábado da semana $2 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("11229f3b-21c0-479c-8d53-12fc0b35ae8f"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6588), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6585), null, false, new Guid("7c3afe4d-2907-4ccb-8ed2-ff6443ed22af"), null, "Rel. Item Cardápio(Sábado da semana $1 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("2e921695-3142-4283-88bb-16b99d1b58dd"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6527), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6524), null, false, new Guid("e40af40f-4b1b-4576-bbac-25211ec68a39"), null, "Rel. Item Cardápio(Sexta-feira da semana $1 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("a59aa095-0bae-4a41-ad5d-fe10ace3cea0"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6736), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6733), null, false, new Guid("2c2fe350-9c5d-4f0a-8d53-8ac4bf7f32f6"), null, "Rel. Item Cardápio(Segunda-feira da semana $2 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("56781146-fc59-4508-85ac-3f904ad0dc2f"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6808), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6805), null, false, new Guid("45c7a224-7153-40f0-aaa0-e50e9204351c"), null, "Rel. Item Cardápio(Terça-feira da semana $2 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("5437f0ce-f1f5-4bd3-96d3-5cdadf14efb0"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6870), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6867), null, false, new Guid("f2378410-219e-4c7a-ac03-8fa6522139da"), null, "Rel. Item Cardápio(Quarta-feira da semana $2 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("d5856178-6358-4475-a9f7-9949277b5a54"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6942), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6939), null, false, new Guid("cdeca2b5-0fb5-4c8c-8b39-e6f2d86abf73"), null, "Rel. Item Cardápio(Quinta-feira da semana $2 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null },
                    { new Guid("84cd1c95-61b2-4ef9-abe2-6e89b4bd67b8"), new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6649), null, new DateTime(2020, 5, 5, 15, 2, 55, 788, DateTimeKind.Utc).AddTicks(6646), null, false, new Guid("10343b07-8b1c-46f0-9a7b-4a61f45fa006"), null, "Rel. Item Cardápio(Domingo da semana $2 - $Café da Manhã) x Receita(Pão de Forma)", new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null }
                });

            migrationBuilder.InsertData(
                table: "item_lista_ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "id_ingrediente", "s_uri", "s_nome", "n_ordem", "n_quantidade", "id_receia", "m_sinonimos", "id_unidade_medida" },
                values: new object[,]
                {
                    { new Guid("028307ab-6407-4c81-aef9-6b35625997c5"), new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(9182), null, new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(9179), null, false, new Guid("fff275f4-152f-43e0-bd2c-f3a86be650fc"), null, "Ovo de galinha", 2, 5.0, new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null, new Guid("6fa17f5c-dafe-4356-9f36-41b9d36c5990") },
                    { new Guid("b8dac617-e191-4999-a200-2d63b2e8ada9"), new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(3538), null, new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(3529), null, false, new Guid("8061d894-dc40-4315-a1bd-f32eb6a13fc0"), null, "Farinha de Trigo", 0, 3.0, new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null, new Guid("3231aeff-289a-4b95-a354-d8fe019e6366") },
                    { new Guid("4fc55a97-7c62-4932-a827-9802fd684659"), new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(8916), null, new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(8908), null, false, new Guid("8061d894-dc40-4315-a1bd-f32eb6a13fc0"), null, "Farinha de Trigo", 0, 3.0, new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null, new Guid("3231aeff-289a-4b95-a354-d8fe019e6366") },
                    { new Guid("cdee2fce-8d9f-4a87-b8e5-aa97983bcee8"), new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(9110), null, new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(9106), null, false, new Guid("c24449e8-03f4-423d-a0b4-bffc207021c0"), null, "Fermento para Pão", 1, 1.0, new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null, new Guid("3231aeff-289a-4b95-a354-d8fe019e6366") },
                    { new Guid("8930c51e-1c63-49bc-b411-14171b98e3f7"), new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(9248), null, new DateTime(2020, 5, 5, 15, 2, 55, 785, DateTimeKind.Utc).AddTicks(9246), null, false, new Guid("42a1cdca-3015-44f3-a1ea-ca6b832b3e38"), null, "Água", 3, 0.5, new Guid("1d7082cc-3d8d-45d7-bdd3-b1f5170563df"), null, new Guid("9c9fb002-47ec-4322-92b9-c035fa8d69dd") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_usuario_id_receita_media",
                table: "avaliacao_usuario",
                column: "id_receita_media",
                unique: true,
                filter: "[id_receita_media] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_usuario_id_receita",
                table: "avaliacao_usuario",
                column: "id_receita");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacao_usuario_id_usuario",
                table: "avaliacao_usuario",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_cardapio_id_cardapio",
                table: "cardapio",
                column: "id_cardapio");

            migrationBuilder.CreateIndex(
                name: "IX_categoria_id_categoria_pai",
                table: "categoria",
                column: "id_categoria_pai");

            migrationBuilder.CreateIndex(
                name: "IX_etapa_preparo_id_receita",
                table: "etapa_preparo",
                column: "id_receita");

            migrationBuilder.CreateIndex(
                name: "IX_info_nutricional_id_ingrediente",
                table: "info_nutricional",
                column: "id_ingrediente");

            migrationBuilder.CreateIndex(
                name: "IX_info_nutricional_ReceitaId",
                table: "info_nutricional",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_info_nutricional_id_unidade_medida",
                table: "info_nutricional",
                column: "id_unidade_medida");

            migrationBuilder.CreateIndex(
                name: "IX_ingrediente_id_categoria",
                table: "ingrediente",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_item_cardapio_CardapioId",
                table: "item_cardapio",
                column: "CardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_item_cardapio_receita_ItemCardapioId",
                table: "item_cardapio_receita",
                column: "ItemCardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_item_cardapio_receita_ReceitaId",
                table: "item_cardapio_receita",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_item_lista_ingrediente_id_ingrediente",
                table: "item_lista_ingrediente",
                column: "id_ingrediente");

            migrationBuilder.CreateIndex(
                name: "IX_item_lista_ingrediente_id_receia",
                table: "item_lista_ingrediente",
                column: "id_receia");

            migrationBuilder.CreateIndex(
                name: "IX_item_lista_ingrediente_id_unidade_medida",
                table: "item_lista_ingrediente",
                column: "id_unidade_medida");

            migrationBuilder.CreateIndex(
                name: "IX_receita_id_categoria",
                table: "receita",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_receita_id_fonte",
                table: "receita",
                column: "id_fonte");

            migrationBuilder.CreateIndex(
                name: "IX_receita_id_receita_pai",
                table: "receita",
                column: "id_receita_pai");

            migrationBuilder.CreateIndex(
                name: "IX_unidade_medida_equiv_id_unidade_dest",
                table: "unidade_medida_equiv",
                column: "id_unidade_dest");

            migrationBuilder.CreateIndex(
                name: "IX_unidade_medida_equiv_id_unidade_orig",
                table: "unidade_medida_equiv",
                column: "id_unidade_orig");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacao_usuario");

            migrationBuilder.DropTable(
                name: "etapa_preparo");

            migrationBuilder.DropTable(
                name: "info_nutricional");

            migrationBuilder.DropTable(
                name: "item_cardapio_receita");

            migrationBuilder.DropTable(
                name: "item_lista_ingrediente");

            migrationBuilder.DropTable(
                name: "unidade_medida_equiv");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "item_cardapio");

            migrationBuilder.DropTable(
                name: "ingrediente");

            migrationBuilder.DropTable(
                name: "receita");

            migrationBuilder.DropTable(
                name: "unidade_medida");

            migrationBuilder.DropTable(
                name: "cardapio");

            migrationBuilder.DropTable(
                name: "fonte_prop_intelec");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
