;;; mylsl-mode.el --- sample major mode for editing LSL.

;; Copyright © 2015, by you

;; Author: your name ( your email )
;; Version: 2.0.13
;; Created: 26 Jun 2015
;; Keywords: languages
;; Homepage: http://ergoemacs.org/emacs/elisp_syntax_coloring.html

;; This file is not part of GNU Emacs.

;;; License:

;; You can redistribute this program and/or modify it under the terms of the GNU General Public License version 2.

;;; Commentary:

;; short description here

;; full doc on how to use here


;;; Code:

;; define several category of keywords
(setq keywords '("break" "default" "do" "else" "for" "if" "return" "state" "while") )
(setq types '("float" "integer" "key" "list" "rotation" "string" "vector"))
(setq constants '("ACTIVE" "AGENT" "ALL_SIDES" "ATTACH_BACK"))
(setq events '("at_rot_target" "at_target" "attach"))
(setq functions '("llAbs" "llAcos" "llAddToLandBanList" "llAddToLandPassList"))

;; generate regex string for each category of keywords
(setq keywords-regexp (regexp-opt keywords 'words))
(setq type-regexp (regexp-opt types 'words))
(setq constant-regexp (regexp-opt constants 'words))
(setq event-regexp (regexp-opt events 'words))
(setq functions-regexp (regexp-opt functions 'words))

;; create the list for font-lock.
;; each category of keyword is given a particular face
(setq font-lock-keywords
      `(
        (,type-regexp . font-lock-type-face)
        (,constant-regexp . font-lock-constant-face)
        (,event-regexp . font-lock-builtin-face)
        (,functions-regexp . font-lock-function-name-face)
        (,keywords-regexp . font-lock-keyword-face)
        ;; note: order above matters, because once colored, that part won't change.
        ;; in general, longer words first
        ))

;;;###autoload
(define-derived-mode mode c-mode "lsl mode"
  "Major mode for editing LSL (Linden Scripting Language)…"

  ;; code for syntax highlighting
  (setq font-lock-defaults '((font-lock-keywords))))

;; clear memory. no longer needed
(setq keywords nil)
(setq types nil)
(setq constants nil)
(setq events nil)
(setq functions nil)

;; clear memory. no longer needed
(setq keywords-regexp nil)
(setq types-regexp nil)
(setq constants-regexp nil)
(setq events-regexp nil)
(setq functions-regexp nil)

;; add the mode to the `features' list
(provide 'mode)

;; Local Variables:
;; coding: utf-8
;; End:

;;; mode.el ends here