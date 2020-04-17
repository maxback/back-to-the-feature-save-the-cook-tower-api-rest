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

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[] { new Guid("80d70986-379f-4075-bcce-3384ff191f39"), new DateTime(2020, 4, 15, 5, 2, 23, 879, DateTimeKind.Utc).AddTicks(7131), null, null, new DateTime(2020, 4, 15, 5, 2, 23, 879, DateTimeKind.Utc).AddTicks(7121), null, false, null, "Categorias", "Categoria Raiz" });

            migrationBuilder.InsertData(
                table: "unidade_medida",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "_nome_resumido", "m_sinonimos", "n_tipo" },
                values: new object[,]
                {
                    { new Guid("16029883-a148-4cf7-970f-8a276daf5fe5"), new DateTime(2020, 4, 15, 5, 2, 23, 877, DateTimeKind.Utc).AddTicks(7955), null, new DateTime(2020, 4, 15, 5, 2, 23, 877, DateTimeKind.Utc).AddTicks(7944), null, false, null, "unidade", "un", "unidades,unidade(un)", 2 },
                    { new Guid("52895e0c-c100-433b-9357-6571433ca979"), new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(5872), null, new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(5848), null, false, null, "grama", "g", "gramas,grama(g)", 3 },
                    { new Guid("215fdea2-3fdc-484f-a4a6-3d751f6375a2"), new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6096), null, new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6090), null, false, null, "kilograma", "kg", "kilo,kilos,kilo gramas,kilogramas,kilograma(kg)", 3 },
                    { new Guid("0842234b-4cd9-4b3a-bd08-886daff27f16"), new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6119), null, new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6116), null, false, null, "litro", "l", "litros,litro(l)", 4 },
                    { new Guid("ee21c099-374f-41db-92b1-54c73ac80ecf"), new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6233), null, new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6228), null, false, null, "xícara de chá", "xíc", "xic,cicara de cha, xícara chá, xícaras de chá,xícara(chá)", 4 },
                    { new Guid("7f4bd4f8-e2dd-4829-948f-23e4126f9a87"), new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6416), null, new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6411), null, false, null, "metro", "m", "metros,metro(m)", 1 },
                    { new Guid("b6a495ab-d3ed-4086-8c56-3a78767fbdb4"), new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6531), null, new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(6526), null, false, null, "milimetro", "mm", "milimetros,milimetro(ml)", 1 }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "s_email", "b_fora_uso", "s_uri", "s_login", "s_nome", "s_password", "m_sinonimos", "s_token" },
                values: new object[,]
                {
                    { new Guid("c71f5695-1eaa-4659-8b26-e7635ec820c1"), new DateTime(2020, 4, 15, 5, 2, 23, 866, DateTimeKind.Utc).AddTicks(5839), null, new DateTime(2020, 4, 15, 5, 2, 23, 866, DateTimeKind.Utc).AddTicks(4174), null, "adm@adm.com", false, null, "adm", "Administrador do sistema", "202cb962ac59075b964b07152d234b70", null, null },
                    { new Guid("f232ec53-810e-4465-91b6-ddf0efd5ad5b"), new DateTime(2020, 4, 15, 5, 2, 23, 877, DateTimeKind.Utc).AddTicks(5741), null, new DateTime(2020, 4, 15, 5, 2, 23, 877, DateTimeKind.Utc).AddTicks(5700), null, "teste@teste.com", false, null, "string", "Usuário de testes com login string e senha string", "b45cffe084dd3d20d928bee85e7b0f21", null, null }
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("99302cab-7501-4ac6-94ef-a738a1edbc31"), new DateTime(2020, 4, 15, 5, 2, 23, 879, DateTimeKind.Utc).AddTicks(9043), null, new Guid("80d70986-379f-4075-bcce-3384ff191f39"), new DateTime(2020, 4, 15, 5, 2, 23, 879, DateTimeKind.Utc).AddTicks(9030), null, false, null, "Ingredientes", "Categoria Raiz dos Ingredientes" },
                    { new Guid("54be2e31-e394-4dc8-a5ef-a12d13bc623b"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(876), null, new Guid("80d70986-379f-4075-bcce-3384ff191f39"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(865), null, false, null, "Receitas", "Categoria Raiz das Receitas" }
                });

            migrationBuilder.InsertData(
                table: "unidade_medida_equiv",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "id_unidade_dest", "b_fora_uso", "s_uri", "s_nome", "id_unidade_orig", "nu_razao_orig_dest", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("f86cd186-ef27-4bb4-9e08-b4eba89b4f27"), new DateTime(2020, 4, 15, 5, 2, 23, 879, DateTimeKind.Utc).AddTicks(5667), null, new DateTime(2020, 4, 15, 5, 2, 23, 879, DateTimeKind.Utc).AddTicks(5645), null, new Guid("0842234b-4cd9-4b3a-bd08-886daff27f16"), false, null, "xícaras de chá pra litros", new Guid("ee21c099-374f-41db-92b1-54c73ac80ecf"), 0.25, "razão xíc/l, xícara de chá apra litros,xíc para l,xic para l" },
                    { new Guid("5e4a0fa3-e450-444b-9fdb-0b4745f7f689"), new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(8271), null, new DateTime(2020, 4, 15, 5, 2, 23, 878, DateTimeKind.Utc).AddTicks(8260), null, new Guid("b6a495ab-d3ed-4086-8c56-3a78767fbdb4"), false, null, "metro para milimetros", new Guid("7f4bd4f8-e2dd-4829-948f-23e4126f9a87"), 0.001, "razão m/ml, metro para milimetros,m para ml" }
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("16978972-b5be-40ae-ba64-3a397de420e2"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(1116), null, new Guid("54be2e31-e394-4dc8-a5ef-a12d13bc623b"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(1109), null, false, null, "Tortas", "Categoria Raiz das tortas" },
                    { new Guid("433e8455-4724-4e30-bedd-7ae9c8ce50c1"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(1138), null, new Guid("54be2e31-e394-4dc8-a5ef-a12d13bc623b"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(1135), null, false, null, "Café da manhã", "Cafe da manha" },
                    { new Guid("d4b68030-acfb-4132-b4a9-21ae2ad692a6"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(1319), null, new Guid("54be2e31-e394-4dc8-a5ef-a12d13bc623b"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(1315), null, false, null, "Jantar", "Categoria Raiz dos Jantares" }
                });

            migrationBuilder.InsertData(
                table: "ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria", "dt_criacao", "id_usu_criacao", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("a9ff59b2-ed86-411c-846a-ef146263e9cd"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(2503), null, new Guid("99302cab-7501-4ac6-94ef-a738a1edbc31"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(2492), null, false, null, null, "Farinha de Trigo", "Trigo" },
                    { new Guid("c06746fd-cb4b-4405-8a1d-a367fc4df506"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(3968), null, new Guid("99302cab-7501-4ac6-94ef-a738a1edbc31"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(3959), null, false, null, null, "Fermento para Pão", "Fermento biológico" },
                    { new Guid("1c43a6c1-f1d6-4860-b654-3a9c972361f8"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(4090), null, new Guid("99302cab-7501-4ac6-94ef-a738a1edbc31"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(4086), null, false, null, null, "Ovo de galinha", "Ovo" },
                    { new Guid("ad8e82d2-84a1-4bca-8b11-29ff87034636"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(4164), null, new Guid("99302cab-7501-4ac6-94ef-a738a1edbc31"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(4161), null, false, null, null, "Água", "Agua" }
                });

            migrationBuilder.InsertData(
                table: "receita",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_avaliacao_media", "id_categoria", "dt_criacao", "id_usu_criacao", "descricao", "id_fonte", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "id_receita_pai", "n_redimento_porcoes", "m_sinonimos", "n_tempo_preparo_minutos", "m_videos_url" },
                values: new object[] { new Guid("2cbc0ee5-be06-4e78-b094-70e9f21b55a2"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(5198), null, null, new Guid("433e8455-4724-4e30-bedd-7ae9c8ce50c1"), new DateTime(2020, 4, 15, 5, 2, 23, 880, DateTimeKind.Utc).AddTicks(5189), null, null, null, false, null, null, "Pão de Forma", null, 5, "Pão assado", 120, null });

            migrationBuilder.InsertData(
                table: "item_lista_ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "id_ingrediente", "s_uri", "s_nome", "n_ordem", "n_quantidade", "id_receia", "m_sinonimos", "id_unidade_medida" },
                values: new object[,]
                {
                    { new Guid("0e6e5a5b-8c66-4fc3-82c9-69205ba957e6"), new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(2470), null, new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(2457), null, false, new Guid("a9ff59b2-ed86-411c-846a-ef146263e9cd"), null, "Farinha de Trigo", 0, 3.0, new Guid("2cbc0ee5-be06-4e78-b094-70e9f21b55a2"), null, new Guid("ee21c099-374f-41db-92b1-54c73ac80ecf") },
                    { new Guid("2c649115-d4f2-4ea7-9c1e-8d47506b4a15"), new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(8335), null, new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(8324), null, false, new Guid("a9ff59b2-ed86-411c-846a-ef146263e9cd"), null, "Farinha de Trigo", 0, 3.0, new Guid("2cbc0ee5-be06-4e78-b094-70e9f21b55a2"), null, new Guid("ee21c099-374f-41db-92b1-54c73ac80ecf") },
                    { new Guid("5703b3b6-7948-4811-b314-0adad8f0ffec"), new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(8531), null, new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(8526), null, false, new Guid("c06746fd-cb4b-4405-8a1d-a367fc4df506"), null, "Fermento para Pão", 1, 1.0, new Guid("2cbc0ee5-be06-4e78-b094-70e9f21b55a2"), null, new Guid("ee21c099-374f-41db-92b1-54c73ac80ecf") },
                    { new Guid("620808ef-ee31-4747-8b41-df2fb1d1145c"), new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(8607), null, new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(8603), null, false, new Guid("1c43a6c1-f1d6-4860-b654-3a9c972361f8"), null, "Ovo de galinha", 2, 5.0, new Guid("2cbc0ee5-be06-4e78-b094-70e9f21b55a2"), null, new Guid("16029883-a148-4cf7-970f-8a276daf5fe5") },
                    { new Guid("469b1a76-8a82-4761-939f-53db9317e70f"), new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(8676), null, new DateTime(2020, 4, 15, 5, 2, 23, 881, DateTimeKind.Utc).AddTicks(8673), null, false, new Guid("ad8e82d2-84a1-4bca-8b11-29ff87034636"), null, "Água", 3, 0.5, new Guid("2cbc0ee5-be06-4e78-b094-70e9f21b55a2"), null, new Guid("0842234b-4cd9-4b3a-bd08-886daff27f16") }
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
                name: "item_lista_ingrediente");

            migrationBuilder.DropTable(
                name: "unidade_medida_equiv");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "ingrediente");

            migrationBuilder.DropTable(
                name: "receita");

            migrationBuilder.DropTable(
                name: "unidade_medida");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "fonte_prop_intelec");
        }
    }
}
