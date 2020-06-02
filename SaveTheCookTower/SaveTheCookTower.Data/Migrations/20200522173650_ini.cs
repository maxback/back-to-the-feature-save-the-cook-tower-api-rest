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
                    n_redimento_porcoes = table.Column<int>(nullable: false),
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
                    m_imagens_url = table.Column<string>(nullable: true),
                    id_unidade_medida_compras = table.Column<Guid>(nullable: false),
                    id_unidade_medida_default = table.Column<Guid>(nullable: false),
                    n_densidade = table.Column<double>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_ingrediente_unidade_medida_id_unidade_medida_default",
                        column: x => x.id_unidade_medida_default,
                        principalTable: "unidade_medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ingrediente_unidade_medida_id_unidade_medida_compras",
                        column: x => x.id_unidade_medida_compras,
                        principalTable: "unidade_medida",
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
                        principalColumn: "id");
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
                        principalColumn: "id");
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
                values: new object[] { new Guid("eb16b590-83ee-472b-a7ba-b33d30a36cd5"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(895), null, null, new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(884), null, false, null, "Categorias", "Categoria Raiz" });

            migrationBuilder.InsertData(
                table: "unidade_medida",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "_nome_resumido", "m_sinonimos", "n_tipo" },
                values: new object[,]
                {
                    { new Guid("4296699a-4370-4070-8e75-ddd37c8cc0d8"), new DateTime(2020, 5, 22, 17, 36, 48, 390, DateTimeKind.Utc).AddTicks(8653), null, new DateTime(2020, 5, 22, 17, 36, 48, 390, DateTimeKind.Utc).AddTicks(8640), null, false, null, "unidade", "un", "unidades,unidade(un)", 2 },
                    { new Guid("44b76a8a-9897-457c-91f0-0037e92d114f"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3404), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3390), null, false, null, "grama", "g", "gramas,grama(g)", 3 },
                    { new Guid("e54fb3fb-7d81-4f5d-ad6d-4d4852277c0c"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3509), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3504), null, false, null, "kilograma", "kg", "kilo,kilos,kilo gramas,kilogramas,kilograma(kg)", 3 },
                    { new Guid("b7d0d1bf-1e55-4cb6-ba21-9ea9d5425d44"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3653), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3647), null, false, null, "litro", "l", "litros,litro(l)", 4 },
                    { new Guid("7d05ae5f-4b7e-433b-989c-dbe5c895d888"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3826), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3819), null, false, null, "xícara de chá", "xíc", "xic,cicara de cha, xícara chá, xícaras de chá,xícara(chá)", 4 },
                    { new Guid("0561f494-fbdc-417a-994c-8575fe591f46"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3975), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(3969), null, false, null, "pitada", "pt", "pitada,punhadinho,cadinho", 4 },
                    { new Guid("765f0b3c-9afc-445a-8229-ba4dea18814c"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4200), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4194), null, false, null, "colher de sopa", "cso", "colher media", 4 },
                    { new Guid("d1b0b9d9-156d-4d56-bc1c-a6b7411c388b"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4326), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4320), null, false, null, "fatia", "fat", "fatia", 4 },
                    { new Guid("c93111f3-8a18-4140-8f64-aa408235b22d"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4448), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4441), null, false, null, "unidade", "un", "unidade", 2 },
                    { new Guid("bbf5b668-695e-40b6-9704-fe1be0b856ca"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4095), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4089), null, false, null, "colher de chá", "ccha", "colher pequena", 4 },
                    { new Guid("15248aae-5d15-441c-a9f4-df13809ad4f9"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4639), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4632), null, false, null, "metro", "m", "metros,metro(m)", 1 },
                    { new Guid("e4bb9405-db2e-4007-a7d6-b5d0dd24d0a7"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4754), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(4749), null, false, null, "milimetro", "mm", "milimetros,milimetro(ml)", 1 }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "s_email", "b_fora_uso", "s_uri", "s_login", "s_nome", "s_password", "m_sinonimos", "s_token" },
                values: new object[,]
                {
                    { new Guid("43945158-f499-469f-9fc4-529fd0d20a0f"), new DateTime(2020, 5, 22, 17, 36, 48, 376, DateTimeKind.Utc).AddTicks(3533), null, new DateTime(2020, 5, 22, 17, 36, 48, 376, DateTimeKind.Utc).AddTicks(1708), null, "adm@adm.com", false, null, "adm", "Administrador do sistema", "202cb962ac59075b964b07152d234b70", null, null },
                    { new Guid("065cd25a-49a3-43f0-91ec-1f3c53e4355b"), new DateTime(2020, 5, 22, 17, 36, 48, 390, DateTimeKind.Utc).AddTicks(5751), null, new DateTime(2020, 5, 22, 17, 36, 48, 390, DateTimeKind.Utc).AddTicks(5694), null, "teste@teste.com", false, null, "string", "Usuário de testes com login string e senha string", "b45cffe084dd3d20d928bee85e7b0f21", null, null }
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("3741c81c-85f8-4ad1-be11-c5bbbf852ee0"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(2808), null, new Guid("eb16b590-83ee-472b-a7ba-b33d30a36cd5"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(2797), null, false, null, "Ingredientes", "Categoria Raiz dos Ingredientes" },
                    { new Guid("0a43169e-7b51-4e2f-8c78-5405aff21ae1"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(4971), null, new Guid("eb16b590-83ee-472b-a7ba-b33d30a36cd5"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(4965), null, false, null, "Cardápios", "Categoria Raiz dos Cardápios" },
                    { new Guid("491970f8-e8f6-46a5-b04c-e3d7b6748f1e"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(5090), null, new Guid("eb16b590-83ee-472b-a7ba-b33d30a36cd5"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(5084), null, false, null, "Receitas", "Categoria Raiz das Receitas" }
                });

            migrationBuilder.InsertData(
                table: "unidade_medida_equiv",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "id_unidade_dest", "b_fora_uso", "s_uri", "s_nome", "id_unidade_orig", "nu_razao_orig_dest", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("41b47db4-9b9f-4579-9d53-4a80204e6ca3"), new DateTime(2020, 5, 22, 17, 36, 48, 392, DateTimeKind.Utc).AddTicks(9236), null, new DateTime(2020, 5, 22, 17, 36, 48, 392, DateTimeKind.Utc).AddTicks(9210), null, new Guid("b7d0d1bf-1e55-4cb6-ba21-9ea9d5425d44"), false, null, "xícaras de chá pra litros", new Guid("7d05ae5f-4b7e-433b-989c-dbe5c895d888"), 0.25, "razão xíc/l, xícara de chá apra litros,xíc para l,xic para l" },
                    { new Guid("b877a3d0-e823-4314-89b8-f6edd4a64624"), new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(7348), null, new DateTime(2020, 5, 22, 17, 36, 48, 391, DateTimeKind.Utc).AddTicks(7334), null, new Guid("e4bb9405-db2e-4007-a7d6-b5d0dd24d0a7"), false, null, "metro para milimetros", new Guid("15248aae-5d15-441c-a9f4-df13809ad4f9"), 0.001, "razão m/ml, metro para milimetros,m para ml" }
                });

            migrationBuilder.InsertData(
                table: "cardapio",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_cardapio", "dt_criacao", "id_usu_criacao", "m_descricao", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "m_sinonimos", "m_videos_url" },
                values: new object[] { new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(7270), null, new Guid("0a43169e-7b51-4e2f-8c78-5405aff21ae1"), new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(7260), null, "Dieta abase de pão comum", false, null, null, "Comendo pão no café da manhã todo dia (mensal)", "café", null });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("913ec87d-b284-482e-b7bb-ecb13909bc4c"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(4520), null, new Guid("3741c81c-85f8-4ad1-be11-c5bbbf852ee0"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(4508), null, false, null, "Carnes", "carnes" },
                    { new Guid("c9a311c1-5649-43fb-81d0-be3e0d99a5eb"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(4709), null, new Guid("3741c81c-85f8-4ad1-be11-c5bbbf852ee0"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(4702), null, false, null, "hortifrutigranjeiro", "hortaliças,frutas,verduras,ovos,hortifruti" },
                    { new Guid("a84e2540-aa92-4053-98cf-9f02d2795287"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(4837), null, new Guid("3741c81c-85f8-4ad1-be11-c5bbbf852ee0"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(4830), null, false, null, "geral", "geral" },
                    { new Guid("7a604a08-0afe-4cdf-bc4e-8ab774a6845e"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(5316), null, new Guid("491970f8-e8f6-46a5-b04c-e3d7b6748f1e"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(5310), null, false, null, "Tortas", "Categoria Raiz das tortas" },
                    { new Guid("e6edeaf6-b0c7-41d2-b1a5-f494ae491c5d"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(5344), null, new Guid("491970f8-e8f6-46a5-b04c-e3d7b6748f1e"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(5340), null, false, null, "Café da manhã", "Cafe da manha" },
                    { new Guid("e8140b18-0758-4c47-9b46-9f9d92d71982"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(5553), null, new Guid("491970f8-e8f6-46a5-b04c-e3d7b6748f1e"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(5546), null, false, null, "Jantar", "Categoria Raiz dos Jantares" }
                });

            migrationBuilder.InsertData(
                table: "ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria", "dt_criacao", "id_usu_criacao", "n_densidade", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "m_sinonimos", "id_unidade_medida_default", "id_unidade_medida_compras" },
                values: new object[,]
                {
                    { new Guid("4cc1267d-52f3-4206-ba0b-0306fd609288"), new DateTime(2020, 5, 22, 17, 36, 48, 396, DateTimeKind.Utc).AddTicks(4044), null, new Guid("c9a311c1-5649-43fb-81d0-be3e0d99a5eb"), new DateTime(2020, 5, 22, 17, 36, 48, 396, DateTimeKind.Utc).AddTicks(4037), null, 1.0, false, null, null, "Ovo de galinha", "Ovo", new Guid("4296699a-4370-4070-8e75-ddd37c8cc0d8"), new Guid("4296699a-4370-4070-8e75-ddd37c8cc0d8") },
                    { new Guid("dc5a1909-341a-40e4-b3dc-d1ca07e67059"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(6874), null, new Guid("a84e2540-aa92-4053-98cf-9f02d2795287"), new DateTime(2020, 5, 22, 17, 36, 48, 393, DateTimeKind.Utc).AddTicks(6863), null, 700.0, false, null, null, "Farinha de Trigo", "Trigo", new Guid("7d05ae5f-4b7e-433b-989c-dbe5c895d888"), new Guid("e54fb3fb-7d81-4f5d-ad6d-4d4852277c0c") },
                    { new Guid("a7c71c26-0d29-42c2-8e1b-76e23f3e9ef1"), new DateTime(2020, 5, 22, 17, 36, 48, 396, DateTimeKind.Utc).AddTicks(3754), null, new Guid("a84e2540-aa92-4053-98cf-9f02d2795287"), new DateTime(2020, 5, 22, 17, 36, 48, 396, DateTimeKind.Utc).AddTicks(3724), null, 1000.0, false, null, null, "Fermento para Pão", "Fermento biológico", new Guid("7d05ae5f-4b7e-433b-989c-dbe5c895d888"), new Guid("e54fb3fb-7d81-4f5d-ad6d-4d4852277c0c") },
                    { new Guid("fb59ec23-8409-4bae-ad0e-319631947287"), new DateTime(2020, 5, 22, 17, 36, 48, 396, DateTimeKind.Utc).AddTicks(4165), null, new Guid("a84e2540-aa92-4053-98cf-9f02d2795287"), new DateTime(2020, 5, 22, 17, 36, 48, 396, DateTimeKind.Utc).AddTicks(4159), null, 1.0, false, null, null, "Água", "Agua", new Guid("b7d0d1bf-1e55-4cb6-ba21-9ea9d5425d44"), new Guid("b7d0d1bf-1e55-4cb6-ba21-9ea9d5425d44") }
                });

            migrationBuilder.InsertData(
                table: "item_cardapio",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "CardapioId", "dt_criacao", "id_usu_criacao", "n_dia_da_semana", "b_fora_uso", "s_uri", "s_nome", "n_porcoes", "n_semana", "m_sinonimos", "Tipo" },
                values: new object[,]
                {
                    { new Guid("0e62835f-1f06-4045-a4d9-7aec852773a0"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(233), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(226), null, 3, false, null, "Café da Manhã, Terça-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("f78a348c-6979-40a9-bfd1-76ac2690f37e"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(553), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(546), null, 4, false, null, "Café da Manhã, Quarta-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("4771f933-2132-4fd9-a1a4-a14d82864b95"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(1028), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(1019), null, 5, false, null, "Café da Manhã, Quinta-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("658dd4cd-77b4-4ff6-a042-9ff1ca063537"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(1412), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(1405), null, 6, false, null, "Café da Manhã, Sexta-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("af041e7b-dad9-491f-ba06-010a2bac55b6"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(1744), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(1737), null, 7, false, null, "Café da Manhã, Sábado da 3a semana ", 1, 3, null, 1 },
                    { new Guid("1acde7f7-2cc4-4f54-b11e-6c8842610188"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(2350), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(2343), null, 2, false, null, "Café da Manhã, Segunda-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("93f2f5bf-7ed3-4130-9d1f-bb53dd47e22d"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(9928), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(9921), null, 2, false, null, "Café da Manhã, Segunda-feira da 3a semana ", 1, 3, null, 1 },
                    { new Guid("25981828-2415-4640-babf-3fb50b70d6c7"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(2663), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(2656), null, 3, false, null, "Café da Manhã, Terça-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("da136b89-1752-46b1-895c-b49de8ee184b"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(3008), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(2999), null, 4, false, null, "Café da Manhã, Quarta-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("632f5b6e-e61a-4613-8471-bd8c76672e28"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(3430), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(3420), null, 5, false, null, "Café da Manhã, Quinta-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("51a1151f-1b4c-4b34-994c-b4647bc79b59"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(3773), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(3766), null, 6, false, null, "Café da Manhã, Sexta-feira da 4a semana ", 1, 4, null, 1 },
                    { new Guid("a7c6dd35-0ed7-40f9-a1be-df6da815b6ed"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(2052), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(2045), null, 1, false, null, "Café da Manhã, Domingo da 4a semana ", 1, 4, null, 1 },
                    { new Guid("fbce18bb-52bb-42aa-9473-c65f1cda3c41"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(9618), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(9611), null, 1, false, null, "Café da Manhã, Domingo da 3a semana ", 1, 3, null, 1 },
                    { new Guid("abe38d84-9d2a-415d-87f1-072f8da106f9"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(9014), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(9007), null, 6, false, null, "Café da Manhã, Sexta-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("afb7fa4c-213e-4f3a-b373-d82b711f9ec3"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(4126), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(4118), null, 7, false, null, "Café da Manhã, Sábado da 4a semana ", 1, 4, null, 1 },
                    { new Guid("1f0afa28-e22a-4aac-b2a4-dabd85d811bd"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(8699), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(8692), null, 5, false, null, "Café da Manhã, Quinta-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("2754dad9-322a-4b7b-97d0-c6593ea2b2a5"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(8339), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(8330), null, 4, false, null, "Café da Manhã, Quarta-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("a4124323-d5e9-4c20-8208-4f9ded9a3df7"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(7948), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(7939), null, 3, false, null, "Café da Manhã, Terça-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("c2e4b2fd-4ac8-46e7-86b6-be7910c39525"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(7561), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(7552), null, 2, false, null, "Café da Manhã, Segunda-feira da 2a semana ", 1, 2, null, 1 },
                    { new Guid("14037ff7-8eb1-4d40-90f8-17d221b71ba5"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(7237), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(7230), null, 1, false, null, "Café da Manhã, Domingo da 2a semana ", 1, 2, null, 1 },
                    { new Guid("1bdc7d55-430e-4aed-a6c4-ef01182ab17a"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(6894), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(6888), null, 7, false, null, "Café da Manhã, Sábado da 1a semana ", 1, 1, null, 1 },
                    { new Guid("bd3471b6-95c4-4d96-9a2f-84e58513f94c"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(6558), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(6550), null, 6, false, null, "Café da Manhã, Sexta-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("c7ee1de6-eea4-47e8-a741-9067a7a424c9"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(6164), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(6152), null, 5, false, null, "Café da Manhã, Quinta-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("9cad21aa-0e6d-4f11-9562-45e557e4d7d2"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(5773), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(5763), null, 4, false, null, "Café da Manhã, Quarta-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("9a65d2d5-969e-42f7-b0cd-581c05f621a3"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(5375), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(5364), null, 3, false, null, "Café da Manhã, Terça-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("7e7955d5-9861-4ae1-afc4-35b6ea3a3e6a"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(4793), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(4774), null, 2, false, null, "Café da Manhã, Segunda-feira da 1a semana ", 1, 1, null, 1 },
                    { new Guid("8a29fe26-41c4-4ed3-a399-20e6b6a5a912"), new DateTime(2020, 5, 22, 17, 36, 48, 401, DateTimeKind.Utc).AddTicks(6581), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 401, DateTimeKind.Utc).AddTicks(6554), null, 1, false, null, "Café da Manhã, Domingo da 1a semana ", 1, 1, null, 1 },
                    { new Guid("0e1763d8-1e3a-49e7-9b47-4dd12f01aff0"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(9312), null, new Guid("01df412d-62b6-4109-862c-9f90994d9737"), new DateTime(2020, 5, 22, 17, 36, 48, 402, DateTimeKind.Utc).AddTicks(9306), null, 7, false, null, "Café da Manhã, Sábado da 2a semana ", 1, 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "receita",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_avaliacao_media", "id_categoria", "dt_criacao", "id_usu_criacao", "descricao", "id_fonte", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "id_receita_pai", "n_redimento_porcoes", "m_sinonimos", "n_tempo_preparo_minutos", "m_videos_url" },
                values: new object[] { new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), new DateTime(2020, 5, 22, 17, 36, 48, 396, DateTimeKind.Utc).AddTicks(6751), null, null, new Guid("e6edeaf6-b0c7-41d2-b1a5-f494ae491c5d"), new DateTime(2020, 5, 22, 17, 36, 48, 396, DateTimeKind.Utc).AddTicks(6736), null, null, null, false, null, null, "Pão de Forma", null, 5, "Pão assado,pao assado", 120, null });

            migrationBuilder.InsertData(
                table: "item_cardapio_receita",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "ItemCardapioId", "s_uri", "s_nome", "ReceitaId", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("002decfc-dd6e-4e5d-aef1-ece657bcda89"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(6252), null, new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(6240), null, false, new Guid("8a29fe26-41c4-4ed3-a399-20e6b6a5a912"), null, "Rel. Item Cardápio(Café da Manhã, Domingo da 1a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("cf3a2be0-3321-4e58-9c64-d32ac208d700"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(3188), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(3183), null, false, new Guid("afb7fa4c-213e-4f3a-b373-d82b711f9ec3"), null, "Rel. Item Cardápio(Café da Manhã, Sábado da 4a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("d7463bce-6795-4636-86d3-7e9f70719bde"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(3080), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(3074), null, false, new Guid("51a1151f-1b4c-4b34-994c-b4647bc79b59"), null, "Rel. Item Cardápio(Café da Manhã, Sexta-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("5dd208a6-21ce-4cb4-b42f-12236e894a3f"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2940), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2935), null, false, new Guid("632f5b6e-e61a-4613-8471-bd8c76672e28"), null, "Rel. Item Cardápio(Café da Manhã, Quinta-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("d72ac824-96f0-4c7f-b66d-07e38aa02781"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2826), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2820), null, false, new Guid("da136b89-1752-46b1-895c-b49de8ee184b"), null, "Rel. Item Cardápio(Café da Manhã, Quarta-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("03932de1-9084-40a5-97c9-818bb6cd99cc"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2711), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2706), null, false, new Guid("25981828-2415-4640-babf-3fb50b70d6c7"), null, "Rel. Item Cardápio(Café da Manhã, Terça-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("bbcc032d-c282-4994-b602-e721ef6f240f"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2562), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2556), null, false, new Guid("1acde7f7-2cc4-4f54-b11e-6c8842610188"), null, "Rel. Item Cardápio(Café da Manhã, Segunda-feira da 4a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("bef4af14-0e8b-4cb1-92f8-ef7ca61570a7"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2438), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2431), null, false, new Guid("a7c6dd35-0ed7-40f9-a1be-df6da815b6ed"), null, "Rel. Item Cardápio(Café da Manhã, Domingo da 4a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("b5f1a667-cc35-4237-8806-2058a462511d"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2307), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2301), null, false, new Guid("af041e7b-dad9-491f-ba06-010a2bac55b6"), null, "Rel. Item Cardápio(Café da Manhã, Sábado da 3a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("33315b61-b3eb-481a-b961-647f16ced050"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2178), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2172), null, false, new Guid("658dd4cd-77b4-4ff6-a042-9ff1ca063537"), null, "Rel. Item Cardápio(Café da Manhã, Sexta-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("c7360935-bbda-4e06-b03e-3393f0285e8d"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2054), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(2049), null, false, new Guid("4771f933-2132-4fd9-a1a4-a14d82864b95"), null, "Rel. Item Cardápio(Café da Manhã, Quinta-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("13b26730-2ea1-4043-a33e-ad585dbe2133"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1946), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1941), null, false, new Guid("f78a348c-6979-40a9-bfd1-76ac2690f37e"), null, "Rel. Item Cardápio(Café da Manhã, Quarta-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("71cee9cb-94d4-42ee-82f8-91d57d68639c"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1714), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1709), null, false, new Guid("93f2f5bf-7ed3-4130-9d1f-bb53dd47e22d"), null, "Rel. Item Cardápio(Café da Manhã, Segunda-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("7fedf460-239a-4bd8-9e20-e1f7d53d568f"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1558), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1553), null, false, new Guid("fbce18bb-52bb-42aa-9473-c65f1cda3c41"), null, "Rel. Item Cardápio(Café da Manhã, Domingo da 3a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("76d535c3-b64e-42d6-a54f-39436ea0a52c"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1827), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1822), null, false, new Guid("0e62835f-1f06-4045-a4d9-7aec852773a0"), null, "Rel. Item Cardápio(Café da Manhã, Terça-feira da 3a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("1dd33353-df1d-4439-be24-6d791cabc877"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1341), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1336), null, false, new Guid("abe38d84-9d2a-415d-87f1-072f8da106f9"), null, "Rel. Item Cardápio(Café da Manhã, Sexta-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("5da149c6-34a2-4b84-acf8-94e52b2b0f77"), new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(9841), null, new DateTime(2020, 5, 22, 17, 36, 48, 403, DateTimeKind.Utc).AddTicks(9829), null, false, new Guid("7e7955d5-9861-4ae1-afc4-35b6ea3a3e6a"), null, "Rel. Item Cardápio(Café da Manhã, Segunda-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("bd3fd8cc-160a-4e6f-9f96-24634e92affc"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(44), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(37), null, false, new Guid("9a65d2d5-969e-42f7-b0cd-581c05f621a3"), null, "Rel. Item Cardápio(Café da Manhã, Terça-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("46f93e8b-a2f9-45a4-9af0-fb223eb88b87"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(158), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(153), null, false, new Guid("9cad21aa-0e6d-4f11-9562-45e557e4d7d2"), null, "Rel. Item Cardápio(Café da Manhã, Quarta-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("ababac77-e0cb-4b5a-8758-c6555efdbcf8"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(266), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(262), null, false, new Guid("c7ee1de6-eea4-47e8-a741-9067a7a424c9"), null, "Rel. Item Cardápio(Café da Manhã, Quinta-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("f7cb9393-be4a-43ee-94e8-003cb9d10b9d"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1447), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1443), null, false, new Guid("0e1763d8-1e3a-49e7-9b47-4dd12f01aff0"), null, "Rel. Item Cardápio(Café da Manhã, Sábado da 2a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("4d614a36-2628-4919-8b00-dfb67557e501"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(522), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(516), null, false, new Guid("1bdc7d55-430e-4aed-a6c4-ef01182ab17a"), null, "Rel. Item Cardápio(Café da Manhã, Sábado da 1a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("bf68f277-d7f5-4f38-a174-eabdc38ab7c0"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(399), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(392), null, false, new Guid("bd3471b6-95c4-4d96-9a2f-84e58513f94c"), null, "Rel. Item Cardápio(Café da Manhã, Sexta-feira da 1a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("b797941a-3f48-43ae-9e6b-dd7db7a98012"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(832), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(826), null, false, new Guid("c2e4b2fd-4ac8-46e7-86b6-be7910c39525"), null, "Rel. Item Cardápio(Café da Manhã, Segunda-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("097bf9ee-ff08-439e-93bb-82dc60c7bc2c"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(993), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(986), null, false, new Guid("a4124323-d5e9-4c20-8208-4f9ded9a3df7"), null, "Rel. Item Cardápio(Café da Manhã, Terça-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("e3032fbd-f058-4670-89dd-d31e1ed2928a"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1109), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1103), null, false, new Guid("2754dad9-322a-4b7b-97d0-c6593ea2b2a5"), null, "Rel. Item Cardápio(Café da Manhã, Quarta-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("7bc30a4c-fff5-43f8-91a9-b164f5d7bc5f"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1228), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(1222), null, false, new Guid("1f0afa28-e22a-4aac-b2a4-dabd85d811bd"), null, "Rel. Item Cardápio(Café da Manhã, Quinta-feira da 2a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null },
                    { new Guid("3a65a1ab-9d42-4cf6-b1a4-001f3813c81f"), new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(687), null, new DateTime(2020, 5, 22, 17, 36, 48, 404, DateTimeKind.Utc).AddTicks(679), null, false, new Guid("14037ff7-8eb1-4d40-90f8-17d221b71ba5"), null, "Rel. Item Cardápio(Café da Manhã, Domingo da 2a semana ) x Receita(Pão de Forma)", new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null }
                });

            migrationBuilder.InsertData(
                table: "item_lista_ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "id_ingrediente", "s_uri", "s_nome", "n_ordem", "n_quantidade", "id_receia", "m_sinonimos", "id_unidade_medida" },
                values: new object[,]
                {
                    { new Guid("a16d57dd-e80a-4549-9269-7f5f4ae858a0"), new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(4815), null, new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(4808), null, false, new Guid("4cc1267d-52f3-4206-ba0b-0306fd609288"), null, "Ovo de galinha", 2, 5.0, new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null, new Guid("4296699a-4370-4070-8e75-ddd37c8cc0d8") },
                    { new Guid("f2479c46-0ae1-4b64-bbe4-4194e8d4aba1"), new DateTime(2020, 5, 22, 17, 36, 48, 397, DateTimeKind.Utc).AddTicks(4959), null, new DateTime(2020, 5, 22, 17, 36, 48, 397, DateTimeKind.Utc).AddTicks(4933), null, false, new Guid("dc5a1909-341a-40e4-b3dc-d1ca07e67059"), null, "Farinha de Trigo", 0, 3.0, new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null, new Guid("7d05ae5f-4b7e-433b-989c-dbe5c895d888") },
                    { new Guid("147e21fe-9aaf-4b17-a751-49b656e8b292"), new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(4304), null, new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(4276), null, false, new Guid("dc5a1909-341a-40e4-b3dc-d1ca07e67059"), null, "Farinha de Trigo", 0, 3.0, new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null, new Guid("7d05ae5f-4b7e-433b-989c-dbe5c895d888") },
                    { new Guid("16846250-57a5-4c72-bb06-3e25924f8653"), new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(4686), null, new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(4678), null, false, new Guid("a7c71c26-0d29-42c2-8e1b-76e23f3e9ef1"), null, "Fermento para Pão", 1, 1.0, new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null, new Guid("7d05ae5f-4b7e-433b-989c-dbe5c895d888") },
                    { new Guid("c93d24c5-24dd-4b70-bbbb-83ff2563cd81"), new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(4935), null, new DateTime(2020, 5, 22, 17, 36, 48, 399, DateTimeKind.Utc).AddTicks(4930), null, false, new Guid("fb59ec23-8409-4bae-ad0e-319631947287"), null, "Água", 3, 0.5, new Guid("b16d8585-091a-484d-aac9-02fb25038f9b"), null, new Guid("b7d0d1bf-1e55-4cb6-ba21-9ea9d5425d44") }
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
                name: "IX_ingrediente_id_unidade_medida_default",
                table: "ingrediente",
                column: "id_unidade_medida_default");

            migrationBuilder.CreateIndex(
                name: "IX_ingrediente_id_unidade_medida_compras",
                table: "ingrediente",
                column: "id_unidade_medida_compras");

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
                name: "cardapio");

            migrationBuilder.DropTable(
                name: "unidade_medida");

            migrationBuilder.DropTable(
                name: "fonte_prop_intelec");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
