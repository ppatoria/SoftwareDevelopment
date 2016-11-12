;;;;;;;;;;;;;;;;;;;;;;;;;;
;; package installation ;;
;;;;;;;;;;;;;;;;;;;;;;;;;;
(when (>= emacs-major-version 24)
  (require 'package)
  (package-initialize)
  (add-to-list 'package-archives '("marmalade" . "https://marmalade-repo.org/packages/"))
  (add-to-list 'package-archives '("org" . "http://orgmode.org/elpa/"))
  (add-to-list 'package-archives '("melpa" . "http://melpa.milkbox.net/packages/") t)
  )

;;;;;;;;;;;;;;;;
;; evil mode  ;;
;;;;;;;;;;;;;;;;
(eval-after-load "evil"
  '(progn
     (define-key evil-normal-state-map (kbd "C-h") 'evil-window-left)
     (define-key evil-normal-state-map (kbd "C-j") 'evil-window-down)
     (define-key evil-normal-state-map (kbd "C-k") 'evil-window-up)
     (define-key evil-normal-state-map (kbd "C-l") 'evil-window-right)))
(evil-mode 1)
(evil-leader-mode)
(evil-commentary-mode)
;;(require 'evil-surround)
(global-evil-surround-mode 1)
(global-evil-visualstar-mode 1)
(global-evil-leader-mode)
 ;;(evil-iedit-state)
;;(er/expand-mode)
;;(helm-mode 1)
(ido-mode 1)

;;eval leader mappins
(evil-leader/set-key 
  "w" 'save-buffer
  "q" 'kill-buffer-and-window
  "h" 'dired-jump
  "v" 'split-window-right
  "e" 'pp-eval-last-sexp
  "," 'other-window
  "b" 'ibuffer
  "x" 'helm-M-x
 "e" 'find-file
  "b" 'switch-to-buffer
  "k" 'kill-buffer)

;;;;;;;;;;;;;;;;;;;;;;
;; custom variables ;;
;;;;;;;;;;;;;;;;;;;;;;
(custom-set-variables
 ;; custom-set-variables was added by Custom.
 ;; If you edit it by hand, you could mess it up, so be careful.
 ;; Your init file should contain only one such instance.
 ;; If there is more than one, they won't work right.
 '(ansi-color-faces-vector
   [default bold shadow italic underline bold bold-italic bold])
 '(ansi-color-names-vector
   (vector "#839496" "#dc322f" "#859900" "#b58900" "#268bd2" "#d33682" "#2aa198" "#002b36"))
 '(canlock-password "1f8a0d04e5aca135e4397b01cb33f805d98aab8f")
 '(custom-enabled-themes (quote (sanityinc-solarized-light)))
 '(custom-safe-themes
   (quote
    ("4cf3221feff536e2b3385209e9b9dc4c2e0818a69a1cdb4b522756bcdf4e00a4" "4aee8551b53a43a883cb0b7f3255d6859d766b6c5e14bcb01bed572fcbef4328" default)))
 '(ede-project-directories
   (quote
    ("c:/Users/prashubh/Google Drive/SoftwareDevelopment/Code/CPP")))
 '(fci-rule-color "#073642")
 '(vc-annotate-background nil)
 '(vc-annotate-color-map
   (quote
    ((20 . "#dc322f")
     (40 . "#cb4b16")
     (60 . "#b58900")
     (80 . "#859900")
     (100 . "#2aa198")
     (120 . "#268bd2")
     (140 . "#d33682")
     (160 . "#6c71c4")
     (180 . "#dc322f")
     (200 . "#cb4b16")
     (220 . "#b58900")
     (240 . "#859900")
     (260 . "#2aa198")
     (280 . "#268bd2")
     (300 . "#d33682")
     (320 . "#6c71c4")
     (340 . "#dc322f")
     (360 . "#cb4b16"))))
 '(vc-annotate-very-old-color nil))
(custom-set-faces
 ;; custom-set-faces was added by Custom.
 ;; If you edit it by hand, you could mess it up, so be careful.
 ;; Your init file should contain only one such instance.
 ;; If there is more than one, they won't work right.
 )

;;;;;;;;;;;;;;;;;
;; spell check ;;
;;;;;;;;;;;;;;;;;
(add-to-list 'exec-path "C:/Users/prashubh/Downloads/Aspell/bin")
(setq ispell-program-name "aspell")
;;(setq ispell-personal-dictionary "C:/path/to/your/.ispell")
(require 'ispell)

;;;;;;;;;;;;;;;;;;;;;;
;; org presentation ;;
;;;;;;;;;;;;;;;;;;;;;;
(setq org-reveal-root "")
(load-file "~/.emacs.d/elpa/ox-reveal-20150206.708/ox-reveal.elc")

;;;;;;;;;;;;;;;;;;;;
;; improved occur ;;
;;;;;;;;;;;;;;;;;;;;
(defun occur-symbol-at-point ()
  (interactive)
  (let ((sym (thing-at-point 'symbol)))
    (if sym
        (push (regexp-quote sym) regexp-history)) ;regexp-history defvared in replace.el
    (call-interactively 'occur)))

;;;;;;;;;;;;;;;;;;;;;
;; Functional Keys ;;
;;;;;;;;;;;;;;;;;;;;;
;; f1
(global-set-key [f2]  'split-window-horizontally)
;;f3
(global-set-key [f4]  'find-file)
(global-set-key [f5] 'shell-command)
(global-set-key [f6]  'buffer-menu)
(global-set-key [f7]  'compile) 
(global-set-key [f8]  'next-error)
(global-set-key [S-f8]  'previous-error)
(global-set-key [f9] 'occur-symbol-at-point) ; Escape
;;f10

;;;;;;;;;;;;;;;;;;;
;; c++ mode hook ;;
;;;;;;;;;;;;;;;;;;;
(add-hook 'c++-mode-hook
          (lambda ()
	    (setq comment-start "/* "
		  comment-end " */")))

;;;;;;;;;;;;;;;;;;;;;;;
;; doxygen doc mode  ;;
;;;;;;;;;;;;;;;;;;;;;;;
(load-file "~/.emacs.d/doc-mode.el")
(add-hook 'c-mode-common-hook 'doc-mode)

;;;;;;;;;;;;;;;;;;;;;
;; Solarized color ;;
;;;;;;;;;;;;;;;;;;;;;
(color-theme-sanityinc-solarized-dark)

;;======


(require 'package)
(add-to-list 'package-archives
	     '("melpa" . "http://melpa.milkbox.net/packages/") t)
(package-initialize)

(setq gc-cons-threshold 100000000)
(setq inhibit-startup-message t)

(defalias 'yes-or-no-p 'y-or-n-p)

(defconst demo-packages
  '(anzu
    company
    duplicate-thing
    ggtags
    helm
    helm-gtags
    helm-projectile
    helm-swoop
    ;; function-args
    clean-aindent-mode
    comment-dwim-2
    dtrt-indent
    ws-butler
    iedit
    yasnippet
    smartparens
    projectile
    volatile-highlights
    undo-tree
    zygospore))

(defun install-packages ()
  "Install all required packages."
  (interactive)
  (unless package-archive-contents
    (package-refresh-contents))
  (dolist (package demo-packages)
    (unless (package-installed-p package)
      (package-install package))))

;; (install-packages)

;; this variables must be set before load helm-gtags
;; you can change to any prefix key of your choice
(setq helm-gtags-prefix-key "\C-cg")

(add-to-list 'load-path "~/.emacs.d/custom")

(require 'setup-helm)
(require 'setup-helm-gtags)
;; (require 'setup-ggtags)
(require 'setup-cedet)
(require 'clean-aindent-mode)
(require 'setup-editing)

(windmove-default-keybindings)

;;(require 'function-args)
;;(fa-config-default)
(add-to-list 'load-path "~/.emacs.d/company-mode-master")
(define-key c-mode-map  [(tab)] 'company-complete)
(define-key c++-mode-map  [(tab)] 'company-complete)

;; company
(require 'company)
 (add-hook 'after-init-hook 'global-company-mode)
 (delete 'company-semantic company-backends)
 (define-key c-mode-map  [(tab)] 'company-complete)
 (define-key c++-mode-map  [(tab)] 'company-complete)
 ;; (define-key c-mode-map  [(control tab)] 'company-complete)
 ;; (define-key c++-mode-map  [(control tab)] 'company-complete)

;; company-c-headers
 (add-to-list 'company-backends 'company-c-headers)

;; hs-minor-mode for folding source code
(add-hook 'c-mode-common-hook 'hs-minor-mode)

 ;; Available C style:
 ;; “gnu”: The default style for GNU projects
 ;; “k&r”: What Kernighan and Ritchie, the authors of C used in their book
 ;; “bsd”: What BSD developers use, aka “Allman style” after Eric Allman.
 ;; “whitesmith”: Popularized by the examples that came with Whitesmiths C, an early commercial C compiler.
 ;; “stroustrup”: What Stroustrup, the author of C++ used in his book
 ;; “ellemtel”: Popular C++ coding standards as defined by “Programming in C++, Rules and Recommendations,” Erik Nyquist and Mats Henricson, Ellemtel
 ;; “linux”: What the Linux developers use for kernel development
 ;; “python”: What Python developers use for extension modules
 ;; “java”: The default style for java-mode (see below)
 ;; “user”: When you want to define your own style
 (setq
  c-default-style "linux" ;; set style to "linux"
  )

 (global-set-key (kbd "RET") 'newline-and-indent)  ; automatically indent when press RET

 ;; activate whitespace-mode to view all whitespace characters
 (global-set-key (kbd "C-c w") 'whitespace-mode)

 ;; show unncessary whitespace that can mess up your diff
 (add-hook 'prog-mode-hook (lambda () (interactive) (setq show-trailing-whitespace 1)))

 ;; use space to indent by default
 (setq-default indent-tabs-mode nil)

 ;; set appearance of a tab that is represented by 4 spaces
 (setq-default tab-width 4)

 ;; Compilation
 (global-set-key (kbd "<f5>") (lambda ()
                                (interactive)
                                (setq-local compilation-read-command nil)
                                (call-interactively 'compile)))

 ;; setup GDB
 (setq
  ;; use gdb-many-windows by default
  gdb-many-windows t

  ;; Non-nil means display source file containing the main routine at startup
  gdb-show-main t
  )

 ;; Package: clean-aindent-mode
 (require 'clean-aindent-mode)
 (add-hook 'prog-mode-hook 'clean-aindent-mode)

 ;; Package: dtrt-indent
 (require 'dtrt-indent)
 (dtrt-indent-mode 1)

 ;; Package: ws-butler
 (require 'ws-butler)
 (add-hook 'prog-mode-hook 'ws-butler-mode)

 ;; Package: yasnippet
 (require 'yasnippet)
 (yas-global-mode 1)

 ;; Package: smartparens
 (require 'smartparens-config)
 (setq sp-base-key-bindings 'paredit)
 (setq sp-autoskip-closing-pair 'always)
 (setq sp-hybrid-kill-entire-symbol nil)
 (sp-use-paredit-bindings)

 (show-smartparens-global-mode +1)
 (smartparens-global-mode 1)

(add-to-list 'load-path "~/.emacs.d/projectile-master")
 ;; Package: projejctile
 (require 'projectile)
 (projectile-global-mode)
 (setq projectile-enable-caching t)

;; (require 'helm-projectile)
 ;;(helm-projectile-on)
 ;;(setq projectile-completion-system 'helm)
 ;;(setq projectile-indexing-method 'alien)

 ;; Package zygospore
 (global-set-key (kbd "C-x 1") 'zygospore-toggle-delete-other-windows)
