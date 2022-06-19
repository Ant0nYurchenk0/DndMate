using AutoMapper;
using DndMate.WebApp.Dtos;
using DndMate.WebApp.Models;
using DndMate.WebApp.Repositories;
using DndMate.WebApp.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace DndMate.WebApp.Controllers
{
    [Authorize]

    public class CharactersController : Controller
    {
        private ApplicationDbContext _context;
        private CharactersRepository _repository;
        private GamespaceRepository _gamespaceRepository;


        // GET: Characters
        public CharactersController(ApplicationDbContext context, CharactersRepository repository, GamespaceRepository gamespaceRepository)
        {
            _context = context;
            _repository = repository;
            _gamespaceRepository = gamespaceRepository;
        }
        public ActionResult Index(int gamespaceId)
        {
            var viewModel = new CharacterListViewModel();
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(gamespaceId, User.Identity.GetUserId());
            viewModel.Characters = _repository.GetCharacters(gamespaceId);
            return View(viewModel);
        }
        public ActionResult AssignSpell(int charId, int spellId)
        {
            var gamespaceId = _context.Characters.Single(c => c.Id == charId).GamespaceId;
            if (!_context.CharacterSpells.Any(cs => cs.CharacterId == charId && cs.SpellId == spellId))
            {
                var characterSpell = new GamespaceCharacterSpell();
                characterSpell.CharacterId = charId;
                characterSpell.SpellId = spellId;
                characterSpell.IsActive = false;
                _context.CharacterSpells.Add(characterSpell);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Spells", new { gamespaceId = gamespaceId });
        }
        public ActionResult DropSpell(int charId, int spellId)
        {
            var gamespaceId = _context.Characters.Single(c => c.Id == charId).GamespaceId;
            var characterSpell = _context.CharacterSpells.SingleOrDefault(cs => cs.CharacterId == charId && cs.SpellId == spellId);
            if (characterSpell == null)
                return HttpNotFound();
            _context.CharacterSpells.Remove(characterSpell);
            _context.SaveChanges();

            return RedirectToAction("Index", "Spells", new { gamespaceId = gamespaceId });
        }
        [Route("Characters/Create")]
        public ActionResult Create(string charId, int gamespaceId)
        {
            var viewModel = new CharacterViewModel();
            viewModel.Character = new GamespaceCharDto();
            viewModel.Gamespace = new GamespacePropsViewModel();
            viewModel.Character.CharacterId = charId;
            viewModel.Character.GamespaceId = gamespaceId;
            return View("Form", viewModel);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(CharacterViewModel form, string page = null)
        {
            var characterDto = form.Character;
            if (!ModelState.IsValid)
                return View("Form", form);

            if (!_context.Characters.Any(s => s.Id == characterDto.Id))
            {
                characterDto.CurrentHP = characterDto.MaxHP;
                _context.Characters.Add(Mapper.Map<GamespaceChar>(characterDto));
            }
            else
            {
                var spellInDb = _context.Characters.SingleOrDefault(s => s.Id == characterDto.Id);
                Mapper.Map(characterDto, spellInDb);
            }
            _context.SaveChanges();
            if (string.IsNullOrEmpty(page))
                return RedirectToAction("Get", "Gamespace", new { id = characterDto.GamespaceId });
            else
                return RedirectToAction("Get", "Characters", new { id = characterDto.Id });

        }
        [Route("Characters/Edit")]
        public ActionResult Edit(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            if (character == null)
                return HttpNotFound();
            var viewModel = new CharacterViewModel();
            viewModel.Character = Mapper.Map<GamespaceCharDto>(character);
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(character.GamespaceId, User.Identity.GetUserId());
            return View("Form", viewModel);
        }
        public ActionResult Get(int id)
        {
            var viewModel = new CharacterViewModel();
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            if (character == null)
                return HttpNotFound();
            viewModel.Character = Mapper.Map<GamespaceCharDto>(character);
            viewModel.Gamespace = _gamespaceRepository.GetViewModel(character.GamespaceId, User.Identity.GetUserId());
            return View(viewModel);
        }
        public ActionResult Heal(int id, int hp)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            character.CurrentHP += hp;
            if (character.CurrentHP > character.MaxHP)
                character.CurrentHP = character.MaxHP;
            _context.SaveChanges();
            return RedirectToAction("Get", "Characters", new { id = id });
        }
        public ActionResult HealAll(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            character.CurrentHP = character.MaxHP;
            _context.SaveChanges();
            return RedirectToAction("Get", "Characters", new { id = id });
        }
        public ActionResult BonusHp(int id, int hp)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            character.BonusHP += hp;
            _context.SaveChanges();
            return RedirectToAction("Get", "Characters", new { id = id });
        }
        public ActionResult Damage(int id, int hp)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            var bonus = character.BonusHP;
            character.BonusHP -= hp;
            hp -= bonus;
            if (hp > 0)
            {
                character.BonusHP = 0;
                character.CurrentHP -= hp;
            }
            if (character.CurrentHP < 0)
                character.CurrentHP = 0;
            _context.SaveChanges();
            return RedirectToAction("Get", "Characters", new { id = id });
        }
        public ActionResult Fail(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            character.Failures++;
            if (character.Failures > 3)
                character.Failures = 3;
            _context.SaveChanges();
            return RedirectToAction("Get", "Characters", new { id = id });
        }
        public ActionResult Succeed(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            character.Successes++;
            if (character.Successes > 3)
                character.Successes = 3;
            _context.SaveChanges();
            return RedirectToAction("Get", "Characters", new { id = id });
        }
        public ActionResult Reset(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            character.Successes = 0;
            character.Failures = 0;
            _context.SaveChanges();
            return RedirectToAction("Get", "Characters", new { id = id });
        }
        public ActionResult RestoreAll(int id)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            character.Level1Used = 0;
            character.Level2Used = 0;
            character.Level3Used = 0;
            character.Level4Used = 0;
            character.Level5Used = 0;
            character.Level6Used = 0;
            character.Level7Used = 0;
            character.Level8Used = 0;
            character.Level9Used = 0;
            character.SpecialUsed = 0;
            _context.SaveChanges();
            return RedirectToAction("Get", "Characters", new { id = id });
        }
        public ActionResult UseSlot(int id, string level, string page = null)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            switch (level)
            {
                case "1":
                    character.Level1Used++;
                    if (character.Level1Used > character.Level1)
                        character.Level1Used = character.Level1;
                    break;
                case "2":
                    character.Level2Used++;
                    if (character.Level2Used > character.Level2)
                        character.Level2Used = character.Level2;
                    break;
                case "3":
                    character.Level3Used++;
                    if (character.Level3Used > character.Level3)
                        character.Level3Used = character.Level3;
                    break;
                case "4":
                    character.Level4Used++;
                    if (character.Level4Used > character.Level4)
                        character.Level4Used = character.Level4;
                    break;
                case "5":
                    character.Level5Used++;
                    if (character.Level5Used > character.Level5)
                        character.Level5Used = character.Level5;
                    break;
                case "6":
                    character.Level6Used++;
                    if (character.Level6Used > character.Level6)
                        character.Level6Used = character.Level6;
                    break;
                case "7":
                    character.Level7Used++;
                    if (character.Level7Used > character.Level7)
                        character.Level7Used = character.Level7;
                    break;
                case "8":
                    character.Level8Used++;
                    if (character.Level8Used > character.Level8)
                        character.Level8Used = character.Level8;
                    break;
                case "9":
                    character.Level9Used++;
                    if (character.Level9Used > character.Level9)
                        character.Level9Used = character.Level9;
                    break;
                case "special":
                    character.SpecialUsed++;
                    if (character.SpecialUsed > character.Special)
                        character.SpecialUsed = character.Special;
                    break;
                default:
                    break;
            }
            _context.SaveChanges();
            if (string.IsNullOrEmpty(page))
                return RedirectToAction("Get", "Characters", new { id = id });
            return RedirectToAction("Index", "Spells", new { gamespaceId = character.GamespaceId });
        }
        public ActionResult RestoreSlot(int id, string level)
        {
            var character = _context.Characters.SingleOrDefault(c => c.Id == id);
            switch (level)
            {
                case "1":
                    character.Level1Used--;
                    if (character.Level1Used < 0)
                        character.Level1Used = 0;
                    break;
                case "2":
                    character.Level2Used--;
                    if (character.Level2Used < 0)
                        character.Level2Used = 0;
                    break;
                case "3":
                    character.Level3Used--;
                    if (character.Level3Used < 0)
                        character.Level3Used = 0;
                    break;
                case "4":
                    character.Level4Used--;
                    if (character.Level4Used < 0)
                        character.Level4Used = 0;
                    break;
                case "5":
                    character.Level5Used--;
                    if (character.Level5Used < 0)
                        character.Level5Used = 0;
                    break;
                case "6":
                    character.Level6Used--;
                    if (character.Level6Used < 0)
                        character.Level6Used = 0;
                    break;
                case "7":
                    character.Level7Used--;
                    if (character.Level7Used < 0)
                        character.Level7Used = 0;
                    break;
                case "8":
                    character.Level8Used--;
                    if (character.Level8Used < 0)
                        character.Level8Used = 0;
                    break;
                case "9":
                    character.Level9Used--;
                    if (character.Level9Used < 0)
                        character.Level9Used = 0;
                    break;
                case "special":
                    character.SpecialUsed--;
                    if (character.SpecialUsed < 0)
                        character.SpecialUsed = 0;
                    break;
                default:
                    break;
            }
            _context.SaveChanges();
            return RedirectToAction("Get", "Characters", new { id = id });
        }

    }
}