import unittest
from unittest.mock import Mock, patch
from trainer import Trainer

class TestTrainer(unittest.TestCase):
    def setUp(self):
        self.mock_reader = Mock()
        self.trainer = Trainer(self.mock_reader)

    def test_toggle_infinite_ammo(self):
        self.assertFalse(self.trainer.infinite_ammo)
        with patch('keyboard.is_pressed', return_value=True):
            self.trainer.handle_input()
        self.assertTrue(self.trainer.infinite_ammo)

    def test_toggle_infinite_health(self):
        self.assertFalse(self.trainer.infinite_health)
        with patch('keyboard.is_pressed', side_effect=[False, True, False]):
            self.trainer.handle_input()
        self.assertTrue(self.trainer.infinite_health)

    def test_apply_cheats_disabled(self):
        self.trainer.apply_cheats()
        self.mock_reader.write_bytes.assert_not_called()

    def test_apply_cheats_enabled(self):
        self.trainer.infinite_ammo = True
        self.trainer.apply_cheats()
        self.mock_reader.write_bytes.assert_called_once_with(0x004A2F10, b'\x90\x90\x90\x90\x90\x90')

    def test_no_reload_toggle(self):
        self.assertFalse(self.trainer.no_reload)
        with patch('keyboard.is_pressed', side_effect=[False, False, True]):
            self.trainer.handle_input()
        self.assertTrue(self.trainer.no_reload)

if __name__ == '__main__':
    unittest.main()