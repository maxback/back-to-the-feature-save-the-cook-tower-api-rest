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
                values: new object[] { new Guid("8cbb65ef-21bf-4751-8239-0b018b154b71"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(2948), null, null, new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(2939), null, false, null, "Categorias", "Categoria Raiz" });

            migrationBuilder.InsertData(
                table: "unidade_medida",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "_nome_resumido", "m_sinonimos", "n_tipo" },
                values: new object[,]
                {
                    { new Guid("e06c7d77-91d2-4ca4-bbae-3240889a058b"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(1146), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(1134), null, false, null, "unidade", "un", "unidades,unidade(un)", 2 },
                    { new Guid("96c8ddb7-0e6e-48ac-8f5d-0842a84f1f6e"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5052), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5042), null, false, null, "grama", "g", "gramas,grama(g)", 3 },
                    { new Guid("98410cd2-ccd1-4d1e-9129-6c02ffe7d32e"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5312), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5308), null, false, null, "kilograma", "kg", "kilo,kilos,kilo gramas,kilogramas,kilograma(kg)", 3 },
                    { new Guid("f76caf8a-2ebe-49d7-8235-a3950904c106"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5327), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5326), null, false, null, "litro", "l", "litros,litro(l)", 4 },
                    { new Guid("21e64e53-3b7a-4f37-afe6-62c42f6119e8"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5403), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5400), null, false, null, "xícara de chá", "xíc", "xic,cicara de cha, xícara chá, xícaras de chá,xícara(chá)", 4 },
                    { new Guid("572def3d-ed91-4f41-a1a4-75bda3efd345"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5476), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5474), null, false, null, "pitada", "pt", "pitada,punhadinho,cadinho", 4 },
                    { new Guid("54700d38-4185-4214-98bc-699e03c5117d"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5596), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5594), null, false, null, "colher de sopa", "cso", "colher media", 4 },
                    { new Guid("a6db85da-bf6f-4082-aeb7-c48f2f1ac096"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5659), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5657), null, false, null, "fatia", "fat", "fatia", 4 },
                    { new Guid("5ff960a1-6ab7-45db-99ab-f61bfcbb639a"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5750), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5747), null, false, null, "unidade", "un", "unidade", 2 },
                    { new Guid("bcdc29b8-8308-4b2b-b61d-cc64ce49fbf4"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5541), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5538), null, false, null, "colher de chá", "ccha", "colher pequena", 4 },
                    { new Guid("b6883dbe-e132-42f3-a0a1-01a355d209bf"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5826), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5823), null, false, null, "metro", "m", "metros,metro(m)", 1 },
                    { new Guid("8793a798-75b8-41f9-9f5b-fca8d3d5340b"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5886), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(5883), null, false, null, "milimetro", "mm", "milimetros,milimetro(ml)", 1 }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "s_email", "b_fora_uso", "s_uri", "s_login", "s_nome", "s_password", "m_sinonimos", "s_token" },
                values: new object[,]
                {
                    { new Guid("7a1dcce0-7548-4786-bb4e-a3f5235d8cde"), new DateTime(2020, 5, 20, 3, 8, 43, 901, DateTimeKind.Utc).AddTicks(8575), null, new DateTime(2020, 5, 20, 3, 8, 43, 901, DateTimeKind.Utc).AddTicks(7287), null, "adm@adm.com", false, null, "adm", "Administrador do sistema", "202cb962ac59075b964b07152d234b70", null, null },
                    { new Guid("b50c6fca-31d3-48ab-b1ef-b584d810bf36"), new DateTime(2020, 5, 20, 3, 8, 43, 914, DateTimeKind.Utc).AddTicks(8455), null, new DateTime(2020, 5, 20, 3, 8, 43, 914, DateTimeKind.Utc).AddTicks(8413), null, "teste@teste.com", false, null, "string", "Usuário de testes com login string e senha string", "b45cffe084dd3d20d928bee85e7b0f21", null, null }
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("aeb5ead3-79e4-4595-b3a9-f5caa92ca058"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(4261), null, new Guid("8cbb65ef-21bf-4751-8239-0b018b154b71"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(4253), null, false, null, "Ingredientes", "Categoria Raiz dos Ingredientes" },
                    { new Guid("70ff797f-14c8-43d0-a7e4-8a2b2f5d6692"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5900), null, new Guid("8cbb65ef-21bf-4751-8239-0b018b154b71"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5895), null, false, null, "Cardápios", "Categoria Raiz dos Cardápios" },
                    { new Guid("f782113b-c4e6-4918-b69e-df0f74b929b4"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5982), null, new Guid("8cbb65ef-21bf-4751-8239-0b018b154b71"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5979), null, false, null, "Receitas", "Categoria Raiz das Receitas" }
                });

            migrationBuilder.InsertData(
                table: "unidade_medida_equiv",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "id_unidade_dest", "b_fora_uso", "s_uri", "s_nome", "id_unidade_orig", "nu_razao_orig_dest", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("6dea2b1a-2d07-4c9b-9223-f6cb5844ce6e"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(1759), null, new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(1745), null, new Guid("f76caf8a-2ebe-49d7-8235-a3950904c106"), false, null, "xícaras de chá pra litros", new Guid("21e64e53-3b7a-4f37-afe6-62c42f6119e8"), 0.25, "razão xíc/l, xícara de chá apra litros,xíc para l,xic para l" },
                    { new Guid("1982a2f6-8d26-429a-8719-cb739b5325da"), new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(7035), null, new DateTime(2020, 5, 20, 3, 8, 43, 915, DateTimeKind.Utc).AddTicks(7025), null, new Guid("8793a798-75b8-41f9-9f5b-fca8d3d5340b"), false, null, "metro para milimetros", new Guid("b6883dbe-e132-42f3-a0a1-01a355d209bf"), 0.001, "razão m/ml, metro para milimetros,m para ml" }
                });

            migrationBuilder.InsertData(
                table: "cardapio",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_cardapio", "dt_criacao", "id_usu_criacao", "m_descricao", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "m_sinonimos", "m_videos_url" },
                values: new object[] { new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(8541), null, new Guid("70ff797f-14c8-43d0-a7e4-8a2b2f5d6692"), new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(8530), null, "Dieta abase de pão comum", false, null, null, "Comendo pão no café da manhã todo dia (mensal)", "café", null });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria_pai", "dt_criacao", "id_usu_criacao", "b_fora_uso", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("b68be1c1-27d4-4c48-b667-e163d26eb681"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5508), null, new Guid("aeb5ead3-79e4-4595-b3a9-f5caa92ca058"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5500), null, false, null, "Carnes", "carnes" },
                    { new Guid("08e1e5ad-9ae2-4729-8fbb-77f1426f3d05"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5660), null, new Guid("aeb5ead3-79e4-4595-b3a9-f5caa92ca058"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5656), null, false, null, "hortifrutigranjeiro", "hortaliças,frutas,verduras,ovos,hortifruti" },
                    { new Guid("2ddd92e1-ad5c-45d2-bb2d-ca4148f6fdf9"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5731), null, new Guid("aeb5ead3-79e4-4595-b3a9-f5caa92ca058"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(5728), null, false, null, "geral", "geral" },
                    { new Guid("280092d9-a30f-418d-a066-1fb81197e245"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(6091), null, new Guid("f782113b-c4e6-4918-b69e-df0f74b929b4"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(6088), null, false, null, "Tortas", "Categoria Raiz das tortas" },
                    { new Guid("0dcf5246-fbc6-43c5-a28d-11b443fb367e"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(6102), null, new Guid("f782113b-c4e6-4918-b69e-df0f74b929b4"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(6101), null, false, null, "Café da manhã", "Cafe da manha" },
                    { new Guid("29546daa-16eb-4c3a-9281-c56f83c127ce"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(6212), null, new Guid("f782113b-c4e6-4918-b69e-df0f74b929b4"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(6209), null, false, null, "Jantar", "Categoria Raiz dos Jantares" }
                });

            migrationBuilder.InsertData(
                table: "ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_categoria", "dt_criacao", "id_usu_criacao", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("ed943cd6-7806-4e24-81a8-e38b8349b858"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(8821), null, new Guid("08e1e5ad-9ae2-4729-8fbb-77f1426f3d05"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(8813), null, false, null, null, "Ovo de galinha", "Ovo" },
                    { new Guid("f952a08b-f489-412a-8fd1-ea30fb499145"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(7153), null, new Guid("2ddd92e1-ad5c-45d2-bb2d-ca4148f6fdf9"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(7144), null, false, null, null, "Farinha de Trigo", "Trigo" },
                    { new Guid("a8a6d044-8a7e-4314-a5de-ca0dc92e964e"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(8594), null, new Guid("2ddd92e1-ad5c-45d2-bb2d-ca4148f6fdf9"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(8583), null, false, null, null, "Fermento para Pão", "Fermento biológico" },
                    { new Guid("681a4fad-2829-47e4-ac61-d0406a4c7f36"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(8948), null, new Guid("2ddd92e1-ad5c-45d2-bb2d-ca4148f6fdf9"), new DateTime(2020, 5, 20, 3, 8, 43, 916, DateTimeKind.Utc).AddTicks(8941), null, false, null, null, "Água", "Agua" }
                });

            migrationBuilder.InsertData(
                table: "item_cardapio",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "CardapioId", "dt_criacao", "id_usu_criacao", "n_dia_da_semana", "b_fora_uso", "s_uri", "s_nome", "n_porcoes", "n_semana", "m_sinonimos", "Tipo" },
                values: new object[,]
                {
                    { new Guid("7dae4518-90a0-405f-bd7c-83321aa8f070"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(1653), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(1648), null, 3, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 3, null, 1 },
                    { new Guid("242fb063-0410-4b6e-8b7e-370ffee9edb8"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(1885), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(1879), null, 4, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 3, null, 1 },
                    { new Guid("09c0b785-a043-4e19-b05b-e1f457a1403b"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(2095), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(2090), null, 5, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 3, null, 1 },
                    { new Guid("1f9b0a12-b42f-4c6e-be4d-bffb9c222ddf"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(2301), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(2296), null, 6, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 3, null, 1 },
                    { new Guid("c02879a1-42b5-4b11-832e-f9079456f46b"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(2506), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(2501), null, 7, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 3, null, 1 },
                    { new Guid("cc9c0e14-2928-4e99-ab47-11dbc7aad542"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(3301), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(3295), null, 2, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 4, null, 1 },
                    { new Guid("7214f836-4bf6-4798-8912-756d9fc66615"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(1403), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(1398), null, 2, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 3, null, 1 },
                    { new Guid("f357e058-7609-4993-a69a-51788a52f282"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(3529), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(3525), null, 3, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 4, null, 1 },
                    { new Guid("44e888c9-0cea-4ff5-98a4-08fec317386c"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(3765), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(3760), null, 4, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 4, null, 1 },
                    { new Guid("2d68599e-631f-4f84-b418-ff1c655a19bd"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(3983), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(3978), null, 5, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 4, null, 1 },
                    { new Guid("e99c3418-f6b6-4ccb-838d-afa459309513"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(4207), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(4203), null, 6, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 4, null, 1 },
                    { new Guid("cc7a5c8f-2225-4dcb-b7da-209ed4663317"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(2969), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(2935), null, 1, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 4, null, 1 },
                    { new Guid("1366adb5-c08e-4fc9-a754-d95504f62b33"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(1193), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(1189), null, 1, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 3, null, 1 },
                    { new Guid("040ace79-9c66-40c5-8d90-cf428b468e6a"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(641), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(611), null, 6, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 2, null, 1 },
                    { new Guid("bf577664-520f-45a4-b6a5-a8ea8b01f47f"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(4419), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(4414), null, 7, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 4, null, 1 },
                    { new Guid("ac31a87e-702e-4aa1-8dea-df37f172cfe6"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(325), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(320), null, 5, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 2, null, 1 },
                    { new Guid("3a1dcdcb-560d-47d7-9a7a-fcb725b40d27"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(9996), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(9987), null, 4, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 2, null, 1 },
                    { new Guid("fa85277e-19a0-45d6-9a0d-86eb6e014ed6"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(9586), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(9581), null, 3, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 2, null, 1 },
                    { new Guid("9074c307-7b70-4426-87e9-47a355db1164"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(9366), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(9360), null, 2, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 2, null, 1 },
                    { new Guid("080d1885-d957-4ff7-8ac3-4504783a6a8e"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(9129), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(9125), null, 1, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 2, null, 1 },
                    { new Guid("003e1cf4-55b2-41ab-93f7-b1ce9c14a1e3"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8919), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8914), null, 7, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 1, null, 1 },
                    { new Guid("3c5fa394-112a-4b6c-a55f-ac7b841f0591"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8695), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8690), null, 6, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 1, null, 1 },
                    { new Guid("1c06861c-dc95-4916-844d-46d6f74122fb"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8473), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8468), null, 5, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 1, null, 1 },
                    { new Guid("8d7f0bb2-5235-48fc-9ba9-a4b1191024a9"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8258), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8253), null, 4, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 1, null, 1 },
                    { new Guid("e2c8a624-bdb3-47a4-8cf4-fca0bcb947a9"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8030), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(8024), null, 3, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 1, null, 1 },
                    { new Guid("8f242d5c-240a-4c96-9fcc-4677902c3c5a"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(7632), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(7622), null, 2, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 1, null, 1 },
                    { new Guid("01f65feb-e709-41d8-b9ff-9243bf2d4058"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(2010), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 920, DateTimeKind.Utc).AddTicks(1992), null, 1, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 1, null, 1 },
                    { new Guid("07ec8272-ec8e-4ba0-a5e0-ad1147a5a117"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(967), null, new Guid("80f4e723-4987-4e7a-be9d-85ee03a149f4"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(962), null, 7, false, null, "{diasS[dia]} da semana {semana} - {s}", 1, 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "receita",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "id_avaliacao_media", "id_categoria", "dt_criacao", "id_usu_criacao", "descricao", "id_fonte", "b_fora_uso", "m_imagens_url", "s_uri", "s_nome", "id_receita_pai", "n_redimento_porcoes", "m_sinonimos", "n_tempo_preparo_minutos", "m_videos_url" },
                values: new object[] { new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), new DateTime(2020, 5, 20, 3, 8, 43, 917, DateTimeKind.Utc).AddTicks(355), null, null, new Guid("0dcf5246-fbc6-43c5-a28d-11b443fb367e"), new DateTime(2020, 5, 20, 3, 8, 43, 917, DateTimeKind.Utc).AddTicks(345), null, null, null, false, null, null, "Pão de Forma", null, 5, "Pão assado,pao assado", 120, null });

            migrationBuilder.InsertData(
                table: "item_cardapio_receita",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "ItemCardapioId", "s_uri", "s_nome", "ReceitaId", "m_sinonimos" },
                values: new object[,]
                {
                    { new Guid("d58c496c-a0c6-443a-b8c1-9f768f2f7540"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(5756), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(5746), null, false, new Guid("01f65feb-e709-41d8-b9ff-9243bf2d4058"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("02b9f432-4ecc-4bdb-bcd5-8a8c6d9ffd5a"), new DateTime(2020, 5, 20, 3, 8, 43, 922, DateTimeKind.Utc).AddTicks(169), null, new DateTime(2020, 5, 20, 3, 8, 43, 922, DateTimeKind.Utc).AddTicks(167), null, false, new Guid("bf577664-520f-45a4-b6a5-a8ea8b01f47f"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("f0fe8711-441e-4c15-96c3-0b5cdc336d54"), new DateTime(2020, 5, 20, 3, 8, 43, 922, DateTimeKind.Utc).AddTicks(105), null, new DateTime(2020, 5, 20, 3, 8, 43, 922, DateTimeKind.Utc).AddTicks(102), null, false, new Guid("e99c3418-f6b6-4ccb-838d-afa459309513"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("63f6bed8-e3a6-4532-88fa-5632b9304e95"), new DateTime(2020, 5, 20, 3, 8, 43, 922, DateTimeKind.Utc).AddTicks(39), null, new DateTime(2020, 5, 20, 3, 8, 43, 922, DateTimeKind.Utc).AddTicks(36), null, false, new Guid("2d68599e-631f-4f84-b418-ff1c655a19bd"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("c230d160-ceed-4aef-9929-d20ca3e28b19"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9973), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9970), null, false, new Guid("44e888c9-0cea-4ff5-98a4-08fec317386c"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("e44f89bb-d60b-40ab-a40e-877b933dc539"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9907), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9905), null, false, new Guid("f357e058-7609-4993-a69a-51788a52f282"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("014d9a3b-2605-439c-a0c9-34cf5b071ada"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9843), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9840), null, false, new Guid("cc9c0e14-2928-4e99-ab47-11dbc7aad542"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("46c358eb-0820-46e7-9d90-6ace5d1c9b6d"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9778), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9775), null, false, new Guid("cc7a5c8f-2225-4dcb-b7da-209ed4663317"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("2b2bfe76-6327-4406-9d1c-689857133eb8"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9708), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9704), null, false, new Guid("c02879a1-42b5-4b11-832e-f9079456f46b"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("39c41e01-c98d-4997-886b-072bdc9e5286"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9599), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9596), null, false, new Guid("1f9b0a12-b42f-4c6e-be4d-bffb9c222ddf"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("6f836e6c-5c72-475f-b8b2-bf5536745ae3"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9533), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9530), null, false, new Guid("09c0b785-a043-4e19-b05b-e1f457a1403b"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("b065fc12-fd52-458b-8436-a1bf0f47a867"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9466), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9463), null, false, new Guid("242fb063-0410-4b6e-8b7e-370ffee9edb8"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("07901eef-4a21-4a75-a0b1-a3b57f566985"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9328), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9325), null, false, new Guid("7214f836-4bf6-4798-8912-756d9fc66615"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("f4881d80-6632-42f3-8fc4-7d0fad82c8ed"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9261), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9257), null, false, new Guid("1366adb5-c08e-4fc9-a754-d95504f62b33"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("270ce40e-87a2-4c3f-8b24-adbf4b71ff58"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9394), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9391), null, false, new Guid("7dae4518-90a0-405f-bd7c-83321aa8f070"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("8fde6fe0-5700-447e-9282-b3ddb841bb84"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9122), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9119), null, false, new Guid("040ace79-9c66-40c5-8d90-cf428b468e6a"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("c99a53ef-3b64-4837-97c5-3fc1615a8824"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8232), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8224), null, false, new Guid("8f242d5c-240a-4c96-9fcc-4677902c3c5a"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("ea9a2f0c-4fd4-4009-bf1a-2272726ea8be"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8352), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8348), null, false, new Guid("e2c8a624-bdb3-47a4-8cf4-fca0bcb947a9"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("d4e01a9d-5c87-45b8-bd33-cd6459b58a66"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8427), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8424), null, false, new Guid("8d7f0bb2-5235-48fc-9ba9-a4b1191024a9"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("4f18de6f-c106-425f-aa18-eabbe7cb0e95"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8527), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8524), null, false, new Guid("1c06861c-dc95-4916-844d-46d6f74122fb"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("18a1566e-df13-4fc7-942b-72ec0f929d72"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9194), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9190), null, false, new Guid("07ec8272-ec8e-4ba0-a5e0-ad1147a5a117"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("a33058a6-727c-4695-994f-72571cc0875b"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8677), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8674), null, false, new Guid("003e1cf4-55b2-41ab-93f7-b1ce9c14a1e3"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("d4ab30e5-0cb0-4800-b9ed-8c80c2c54989"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8607), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8604), null, false, new Guid("3c5fa394-112a-4b6c-a55f-ac7b841f0591"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("d18fff23-670a-432a-944a-ad9aac24ec0e"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8813), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8810), null, false, new Guid("9074c307-7b70-4426-87e9-47a355db1164"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("35104d47-7191-40df-9ba2-2f896669b337"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8900), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8897), null, false, new Guid("fa85277e-19a0-45d6-9a0d-86eb6e014ed6"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("f7bce275-d300-4e3d-83c9-7d2d901f3344"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8969), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8966), null, false, new Guid("3a1dcdcb-560d-47d7-9a7a-fcb725b40d27"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("e7504335-028d-4e61-b00e-e61c2202d5c5"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9036), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(9033), null, false, new Guid("ac31a87e-702e-4aa1-8dea-df37f172cfe6"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null },
                    { new Guid("caeb7668-53dd-4007-8f9b-2c0930aa911d"), new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8745), null, new DateTime(2020, 5, 20, 3, 8, 43, 921, DateTimeKind.Utc).AddTicks(8742), null, false, new Guid("080d1885-d957-4ff7-8ac3-4504783a6a8e"), null, "Rel. Item Cardápio({diasS[dia]} da semana {semana} - {s}) x Receita(Pão de Forma)", new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null }
                });

            migrationBuilder.InsertData(
                table: "item_lista_ingrediente",
                columns: new[] { "id", "dt_atualizacao", "id_Usu_atualizacao", "dt_criacao", "id_usu_criacao", "b_fora_uso", "id_ingrediente", "s_uri", "s_nome", "n_ordem", "n_quantidade", "id_receia", "m_sinonimos", "id_unidade_medida" },
                values: new object[,]
                {
                    { new Guid("9c601dd9-08dd-42b5-9a59-2be1d39ac4da"), new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(7039), null, new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(7034), null, false, new Guid("ed943cd6-7806-4e24-81a8-e38b8349b858"), null, "Ovo de galinha", 2, 5.0, new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null, new Guid("e06c7d77-91d2-4ca4-bbae-3240889a058b") },
                    { new Guid("9829953a-43af-4871-ab8d-86dc689b6f0b"), new DateTime(2020, 5, 20, 3, 8, 43, 917, DateTimeKind.Utc).AddTicks(8346), null, new DateTime(2020, 5, 20, 3, 8, 43, 917, DateTimeKind.Utc).AddTicks(8331), null, false, new Guid("f952a08b-f489-412a-8fd1-ea30fb499145"), null, "Farinha de Trigo", 0, 3.0, new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null, new Guid("21e64e53-3b7a-4f37-afe6-62c42f6119e8") },
                    { new Guid("837524ee-3435-4b34-b92c-4301b6c61d79"), new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(6582), null, new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(6569), null, false, new Guid("f952a08b-f489-412a-8fd1-ea30fb499145"), null, "Farinha de Trigo", 0, 3.0, new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null, new Guid("21e64e53-3b7a-4f37-afe6-62c42f6119e8") },
                    { new Guid("2e26e016-6d3c-4f53-953a-704d0a6a0ca8"), new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(6902), null, new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(6895), null, false, new Guid("a8a6d044-8a7e-4314-a5de-ca0dc92e964e"), null, "Fermento para Pão", 1, 1.0, new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null, new Guid("21e64e53-3b7a-4f37-afe6-62c42f6119e8") },
                    { new Guid("495f9ad3-f946-4c7d-b815-37ec223fd613"), new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(7171), null, new DateTime(2020, 5, 20, 3, 8, 43, 918, DateTimeKind.Utc).AddTicks(7166), null, false, new Guid("681a4fad-2829-47e4-ac61-d0406a4c7f36"), null, "Água", 3, 0.5, new Guid("a9b2546b-fdc9-4752-9aea-225c680f1403"), null, new Guid("f76caf8a-2ebe-49d7-8235-a3950904c106") }
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
