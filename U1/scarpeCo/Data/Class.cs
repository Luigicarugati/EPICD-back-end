using System.Collections.Generic;
using ScarpeCo.Models;

namespace ScarpeCo.Data
{
    public static class ArticoloRepository
    {
        public static List<Articolo> Articoli { get; } = new List<Articolo>
        {
            new Articolo
            {
                Id = 1,
                Nome = "Scarpa da Tennis Pro",
                Prezzo = 79.99m,
                Descrizione = "Scarpa da tennis professionale con ottima aderenza.",
                ImmagineCopertina = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/b01c67f2-2481-45d7-b383-a1476d768f6e/air-force-1-07-next-nature-shoes-lkVhs6.png",
                ImmagineAggiuntiva1 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/116c99aa-26ac-4fb0-8f1f-257f7b0664fb/air-force-1-07-next-nature-shoes-lkVhs6.png",
                ImmagineAggiuntiva2 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/116c99aa-26ac-4fb0-8f1f-257f7b0664fb/air-force-1-07-next-nature-shoes-lkVhs6.png"
            },
            new Articolo
            {
                Id = 2,
                Nome = "Scarpa da Tennis Light",
                Prezzo = 59.99m,
                Descrizione = "Scarpa leggera ideale per allenamenti quotidiani.",
                ImmagineCopertina = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/4868cd5b-7e07-4219-a7e9-4b4fa263cd32/custom-v2k-by-you.png",
                ImmagineAggiuntiva1 = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/19b3451c-6b27-422c-9ed3-080b139584ec/custom-v2k-by-you.png",
                ImmagineAggiuntiva2 = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/c9485e0b-a484-48d7-b930-c373c2bf43fd/custom-v2k-by-you.png"
            },
            new Articolo
            {
                Id = 3,
                Nome = "NovaLite XT",
                Prezzo = 129.99m,
                Descrizione = "Le NovaLite XT sono la scelta ideale per i giocatori che cercano leggerezza e agilità. Con una tomaia in mesh traspirante e una suola che offre un grip eccellente, queste scarpe permettono rapidi cambi di direzione.",
                ImmagineCopertina = "https://static.nike.com/a/images/t_prod_ss/w_640,c_limit,f_auto/d43cffa3-7533-4e83-99d4-6cce62be70e8/air-force-1-black-hf8189-001-release-date.jpg",
                ImmagineAggiuntiva1 = "https://static.nike.com/a/images/t_prod_sc/w_640,c_limit,f_auto/1a63a35b-a7a0-4818-9c30-843b93a2c56d/air-force-1-black-hf8189-001-release-date.jpg",
                ImmagineAggiuntiva2 = "https://static.nike.com/a/images/t_prod_ss/w_640,c_limit,f_auto/ea8750e3-19f3-4add-9b4a-7cdea4edbe17/air-force-1-black-hf8189-001-release-date.jpg"
            },
            new Articolo
            {
                Id = 4,
                Nome = "PowerFlex 500",
                Prezzo = 159.99m,
                Descrizione = "Le PowerFlex 500 sono progettate per massimizzare la potenza e la stabilità. Con una suola resistente all'abrasione e un sistema di supporto per l'arco del piede, queste scarpe offrono un'esperienza di gioco robusta e sicura.",
                ImmagineCopertina = "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/89a91ebd-3e3d-4550-b10d-561f6ebba30a/lunar-force-1-duckboot-HrBZjs.png",
                ImmagineAggiuntiva1 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/1503583c-ce53-4126-bd7e-ec449fce5c7f/lunar-force-1-duckboot-HrBZjs.png",
                ImmagineAggiuntiva2 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/4882028c-e518-4d12-bfb9-e40e3c165d1c/lunar-force-1-duckboot-HrBZjs.png"
            },
            new Articolo
            {
                Id = 5,
                Nome = "SwiftShot Elite",
                Prezzo = 189.99m,
                Descrizione = "Le SwiftShot Elite sono state sviluppate per i giocatori competitivi che richiedono il massimo dalle loro calzature. Con una combinazione di materiali leggeri e supporto strutturato, queste scarpe sono ideali per lunghe sessioni di gioco.",
                ImmagineCopertina = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/f4a3d40e-4b40-4aed-bb55-adfaed9bebf1/force-1-mid-easyon-shoes-Nff322.png",
                ImmagineAggiuntiva1 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/2b337181-978d-4d69-abb1-df2a7782610e/force-1-mid-easyon-shoes-Nff322.png",
                ImmagineAggiuntiva2 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/d3c5fc94-c110-4800-b661-e53d207e28e1/force-1-mid-easyon-shoes-Nff322.png"
            },
            new Articolo
            {
                Id = 6,
                Nome = "Blaze Pro X",
                Prezzo = 169.99m,
                Descrizione = "Le Blaze Pro X sono scarpe versatili per i giocatori che desiderano comfort e prestazioni superiori. Con una struttura robusta e un'ammortizzazione reattiva, queste scarpe sono ideali per giocatori di tutti i livelli.",
                ImmagineCopertina = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/b50306f3-0ad7-4e5f-884c-da515b3d67dd/force-1-mid-se-easyon-younger-shoes-wDbbMg.png",
                ImmagineAggiuntiva1 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/b33c9186-29f6-4ad9-91ed-d8c7a88ddcc3/force-1-mid-se-easyon-younger-shoes-wDbbMg.png",
                ImmagineAggiuntiva2 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/870b5540-3cd5-4fea-b2fb-6a34acf7dede/force-1-mid-se-easyon-younger-shoes-wDbbMg.png"
            },
            new Articolo
            {
                Id = 7,
                Nome = "RapidFlex 2000",
                Prezzo = 119.99m,
                Descrizione = "Le RapidFlex 2000 sono scarpe leggere e flessibili per giocatori che prediligono la velocità e la mobilità. Con una tomaia in mesh traspirante e una suola che offre un grip superiore, queste scarpe sono perfette per scatti rapidi in campo.",
                ImmagineCopertina = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/162c2b1d-b107-4f96-8598-28906f4deebd/jordan-1-low-alt-younger-shoes-KKZDsl.png",
                ImmagineAggiuntiva1 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/700ac752-c3f1-4a2b-87d4-cda713902086/jordan-1-low-alt-younger-shoes-KKZDsl.png",
                ImmagineAggiuntiva2 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/ae711a67-07e8-4c2a-a878-e1129200f8dc/jordan-1-low-alt-younger-shoes-KKZDsl.png"
            },
            new Articolo
            {
                Id = 8,
                Nome = "Titanium Drive",
                Prezzo = 199.99m,
                Descrizione = "Le Titanium Drive sono scarpe di alta gamma per giocatori che cercano il meglio in termini di comfort e performance. Con materiali premium e un'ammortizzazione avanzata, queste scarpe garantiscono prestazioni superiori in ogni partita.",
                ImmagineCopertina = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/8402492b-1d6c-4811-af0f-4e3090c2ab59/air-jordan-1-retro-high-og-shoes-BFqZfb.png",
                ImmagineAggiuntiva1 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/feca64f6-b7af-44c7-b437-9ebfac13c327/air-jordan-1-retro-high-og-shoes-BFqZfb.png",
                ImmagineAggiuntiva2 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/dffae457-1781-48a2-8f67-30652f1aa236/air-jordan-1-retro-high-og-shoes-BFqZfb.png"
            },
           
            new Articolo
            {
                Id = 10,
                Nome = "StrikeForce XL",
                Prezzo = 179.99m,
                Descrizione = "Le StrikeForce XL sono scarpe robuste per giocatori che richiedono supporto e trazione superiori. Con un'ammortizzazione avanzata e una costruzione resistente, queste scarpe sono ideali per giocare in qualsiasi condizione atmosferica.",
                ImmagineCopertina = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/4c375aff-47c0-400f-a280-4efdc1669f39/air-jordan-13-retro-dune-red-shoes-rkMPwN.png",
                ImmagineAggiuntiva1 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/854c9504-312a-46ec-ad9a-4fb8d191f5e4/air-jordan-13-retro-dune-red-shoes-rkMPwN.png",
                ImmagineAggiuntiva2 = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/bf827ee4-5566-4147-9077-35d848971e2a/air-jordan-13-retro-dune-red-shoes-rkMPwN.png"
            },
            new Articolo
            {
                Id = 11,
                Nome = "Fury Flex",
                Prezzo = 159.99m,
                Descrizione = "Le Fury Flex sono scarpe dinamiche per giocatori che prediligono la velocità e la reattività. Con una suola leggera e un design ergonomico, queste scarpe sono perfette per giocatori che si muovono rapidamente sul campo.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 12,
                Nome = "UltraDrive 4000",
                Prezzo = 209.99m,
                Descrizione = "Le UltraDrive 4000 sono scarpe premium per giocatori che cercano il massimo in termini di performance e comfort. Con tecnologia di punta e materiali di alta qualità, queste scarpe sono progettate per dominare il campo.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 13,
                Nome = "TurboBoost X",
                Prezzo = 169.99m,
                Descrizione = "Le TurboBoost X sono scarpe innovative per giocatori che cercano un mix di velocità e stabilità. Con una suola reattiva e una tomaia aerodinamica, queste scarpe offrono prestazioni superiori in ogni partita.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 14,
                Nome = "EnduroFlex 300",
                Prezzo = 139.99m,
                Descrizione = "Le EnduroFlex 300 sono scarpe robuste per giocatori che richiedono resistenza e durata. Con una suola antiscivolo e un design ergonomico, queste scarpe sono ideali per partite lunghe e intense.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 15,
                Nome = "Dynamic Drive XT",
                Prezzo = 179.99m,
                Descrizione = "Le Dynamic Drive XT sono scarpe versatili per giocatori che desiderano flessibilità e comfort. Con una tomaia traspirante e una suola che offre un grip eccezionale, queste scarpe sono perfette per giocatori dinamici.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 16,
                Nome = "HyperFlex 600",
                Prezzo = 199.99m,
                Descrizione = "Le HyperFlex 600 sono scarpe di alta gamma per giocatori che cercano il massimo in termini di performance e stabilità. Con una suola reattiva e un'ammortizzazione avanzata, queste scarpe garantiscono prestazioni superiori in ogni partita.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 17,
                Nome = "Striker Pro X",
                Prezzo = 169.99m,
                Descrizione = "Le Striker Pro X sono scarpe leggere per giocatori che prediligono la velocità e l'agilità. Con una tomaia in mesh e una suola leggera, queste scarpe offrono comfort e performance superiori.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 18,
                Nome = "PowerShot Pro",
                Prezzo = 189.99m,
                Descrizione = "Le PowerShot Pro sono scarpe robuste per giocatori che richiedono supporto e stabilità. Con una suola antiscivolo e un design resistente, queste scarpe sono ideali per giocare in qualsiasi condizione atmosferica.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 19,
                Nome = "PrimeForce 3000",
                Prezzo = 159.99m,
                Descrizione = "Le PrimeForce 3000 sono scarpe di alta qualità per giocatori che cercano il massimo comfort e durabilità. Con una suola resistente e un'ammortizzazione avanzata, queste scarpe garantiscono prestazioni superiori in ogni partita.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 20,
                Nome = "TurboFlex 500",
                Prezzo = 209.99m,
                Descrizione = "Le TurboFlex 500 sono scarpe innovative per giocatori che cercano una combinazione di velocità e comfort. Con una tomaia traspirante e una suola reattiva, queste scarpe offrono prestazioni eccezionali in campo.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 21,
                Nome = "StrikePro XL",
                Prezzo = 179.99m,
                Descrizione = "Le StrikePro XL sono scarpe robuste per giocatori che richiedono stabilità e durata. Con una suola antiscivolo e un design ergonomico, queste scarpe sono ideali per partite lunghe e intense.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 22,
                Nome = "VelocityDrive XT",
                Prezzo = 199.99m,
                Descrizione = "Le VelocityDrive XT sono scarpe versatili per giocatori che desiderano flessibilità e comfort. Con una tomaia traspirante e una suola che offre un grip eccezionale, queste scarpe sono perfette per giocatori dinamici.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 23,
                Nome = "RapidShot 2000",
                Prezzo = 149.99m,
                Descrizione = "Le RapidShot 2000 sono scarpe leggere e flessibili per giocatori che prediligono la velocità e la mobilità. Con una tomaia in mesh traspirante e una suola che offre un grip superiore, queste scarpe sono perfette per scatti rapidi in campo.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 24,
                Nome = "ProFlex 400",
                Prezzo = 169.99m,
                Descrizione = "Le ProFlex 400 sono scarpe dinamiche per giocatori che prediligono la velocità e la reattività. Con una suola leggera e un design ergonomico, queste scarpe sono perfette per giocatori che si muovono rapidamente sul campo.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            },
            new Articolo
            {
                Id = 25,
                Nome = "EagleStrike X",
                Prezzo = 189.99m,
                Descrizione = "Le EagleStrike X sono scarpe di alta gamma per giocatori che cercano il massimo in termini di performance e stabilità. Con una suola reattiva e un'ammortizzazione avanzata, queste scarpe garantiscono prestazioni superiori in ogni partita.",
                ImmagineCopertina = "https://picsum.photos/200/300",
                ImmagineAggiuntiva1 = "https://picsum.photos/200/300",
                ImmagineAggiuntiva2 = "https://picsum.photos/200/300"
            }

                    };
                }
            }
